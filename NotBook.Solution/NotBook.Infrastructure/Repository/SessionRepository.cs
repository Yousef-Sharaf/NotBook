using NotBook.Domain.Entities;
using NotBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NotBook.Application.IRepositories;

namespace NotBook.Infrastructure.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Session?> GetByIdAsync(Guid id)
        {
            return await _context.Sessions.FindAsync(id);
        }
        public async Task<Session?> GetByJoinCodeAsync(string joinCode)
        {
            return await _context.Sessions.FirstOrDefaultAsync(s => s.JoinCode == joinCode);
        }

        public async Task AddAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
