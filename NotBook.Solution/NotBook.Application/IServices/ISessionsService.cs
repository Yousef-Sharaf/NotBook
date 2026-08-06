using NotBook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Application.IServices
{
        public interface ISessionService
        {
            Task<SessionResultDto> CreateSessionAsync(CreateSessionDto dto);
            Task<SessionResultDto?> GetSessionByJoinCodeAsync(string joinCode);
            Task<SessionResultDto> JoinSessionAsync(JoinSessionDto dto);

    }
}
