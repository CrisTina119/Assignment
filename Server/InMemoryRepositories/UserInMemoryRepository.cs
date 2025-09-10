using System;
using Entities;
using RepositoryContracts;
using RepositoryContracts.Interfaces;

namespace InMemoryRepositories_;

public class UserInMemoryRepositories : IUserRepository
    {
     public List<User>? users = new();

        public Task<User> AddAsync(User user)
        {
            user.Id = users!.Any() ? users!.Max(u => u.Id) + 1 : 1;
            users!.Add(user);
            return Task.FromResult(user);
        }

        public Task UpdateAsync(User user)
        {
            User? existingUser = users!.SingleOrDefault(u => u.Id == user.Id);
            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID '{user.Id}' not found");
            }

            users!.Remove(existingUser);
            users.Add(user);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            User? existingUser = users!.SingleOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID '{id}' not found");
            }

            users!.Remove(existingUser);
            return Task.CompletedTask;
        }

        public Task<User?> GetSingleAsync(int id)
        {
            User? user = users!.SingleOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public IQueryable<User> GetManyAsync()
        {
            return users!.AsQueryable();
        }
    }
