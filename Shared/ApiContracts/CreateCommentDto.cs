using System;

namespace ApiContracts;

public class CreateCommentDto
{
    public required int PostId { get; set; }
    public required int AuthorUserId { get; set; }
    public required string Body{ get; set; }
}
