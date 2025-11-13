using ApiContracts.PostFolder;
using ApiContracts.UserFolder;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Interfaces;
using Entities;

namespace WebAppi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository postinterface;

        public PostController(IPostRepository postinterface)
        {
            this.postinterface = postinterface;
        }

        // POST /posts
        [HttpPost]
        public async Task<ActionResult<PostDto>> Create([FromBody] CreatePostDto request)
        {
            var post = new Post
            {
                Title = request.Title,
                Body = request.Body,
                UserId = request.AuthorUserId
            };

            var created = await postinterface.AddAsync(post);

            var result = new PostDto
            {
                Id = created.Id,
                Title = created.Title ?? string.Empty,
                Body = created.Body ?? string.Empty,
                AuthorUserId = created.UserId
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // GET /posts/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDto>> GetById(int id)
        {
            Post? p;
            try
            {
                p = await postinterface.GetSingleAsync(id);
            }
            catch
            {
                return NotFound();
            }

            if (p is null) return NotFound();

            return new PostDto
            {
                Id = p.Id,
                Title = p.Title ?? string.Empty,
                Body = p.Body ?? string.Empty,
                AuthorUserId = p.UserId
            };
        }

        // GET /posts
        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> GetMany(
            [FromQuery] string? titleContains,
            [FromQuery] int? authorUserId)
        {
            var q = postinterface.GetManyAsync();

            if (!string.IsNullOrWhiteSpace(titleContains))
            {
                var needle = titleContains.ToLower();
                q = q.Where(p => p.Title != null && p.Title.ToLower().Contains(needle));
            }

            if (authorUserId is not null)
            {
                q = q.Where(p => p.UserId == authorUserId.Value);
            }

            return q.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title ?? string.Empty,
                Body = p.Body ?? string.Empty,
                AuthorUserId = p.UserId
            })
            .ToList();
        }

        // PUT /posts/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreatePostDto dto)
        {
            var post = new Post
            {
                Id = id,
                Title = dto.Title,
                Body = dto.Body,
                UserId = dto.AuthorUserId
            };

            try
            {
                await postinterface.UpdateAsync(post);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE /posts/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await postinterface.DeleteAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}