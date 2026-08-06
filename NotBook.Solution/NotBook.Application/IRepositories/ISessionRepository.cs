using NotBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Application.IRepositories
{
    public interface ISessionRepository
    {
        Task<Session?> GetByIdAsync(Guid id);
        Task<Session?> GetByJoinCodeAsync(string joinCode);
        Task AddAsync(Session session);
        Task SaveChangesAsync();
    }
}
