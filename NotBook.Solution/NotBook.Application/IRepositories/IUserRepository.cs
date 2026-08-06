using NotBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}
