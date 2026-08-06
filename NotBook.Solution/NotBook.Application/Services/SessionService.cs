using System;
using System.Collections.Generic;
using System.Text;
using NotBook.Application.DTOs;
using NotBook.Domain.Entities;
using NotBook.Application.IServices;
using NotBook.Application.IRepositories;


namespace NotBook.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        => _sessionRepository = sessionRepository;

        public async Task<SessionResultDto> CreateSessionAsync(CreateSessionDto dto)
        {
            if (dto.BreakDuration > dto.WorkDuration/5)
            {
                throw new InvalidOperationException("Break duration must be 20% or less of work duration.");
            }
            string JoinCode;
            Session? existing;

            do
            {
                JoinCode = GenerateJoinCode();
                existing = await _sessionRepository.GetByJoinCodeAsync(JoinCode);
            }
            while (existing != null);

            var session = new Session
            {
                JoinCode = JoinCode,
                Name = dto.Name,
                WorkDuration = dto.WorkDuration,
                BreakDuration = dto.BreakDuration,
                CreatedByUserId = dto.CreatedByUserId,
                UpdatedByUserId = dto.CreatedByUserId
            };

            await _sessionRepository.AddAsync(session);
            await _sessionRepository.SaveChangesAsync();

            return new SessionResultDto
            {
                Id = session.Id,
                JoinCode = session.JoinCode,
                Name = session.Name,
                WorkDuration = session.WorkDuration,
                BreakDuration = session.BreakDuration
            };
        }
        private static string GenerateJoinCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Range(0, 6)
                .Select(_ => chars[random.Next(chars.Length)])
                .ToArray());
        }

        public async Task<SessionResultDto> JoinSessionAsync(JoinSessionDto dto)
        {
            var session = await _sessionRepository.GetByJoinCodeAsync(dto.JoinCode);

            if (session == null)
            {
                throw new InvalidOperationException("The code is invalid.");
            }

            return new SessionResultDto
            {
                Id = session.Id,
                JoinCode = session.JoinCode,
                Name = session.Name,
                WorkDuration = session.WorkDuration,
                BreakDuration = session.BreakDuration
            };
        }

        public Task<SessionResultDto?> GetSessionByJoinCodeAsync(string joinCode)
        {
            throw new NotImplementedException();
        }
    }
}
