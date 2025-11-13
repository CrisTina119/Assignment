using System;
using Entities;

namespace RepositoryContracts.Interfaces;

public interface IUserRepository
{
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<User?> GetSingleAsync(int id);
        IQueryable<User> GetManyAsync();
        Task<User?> GetByUserNameAsync(string username);
}
