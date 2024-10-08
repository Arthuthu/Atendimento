﻿using AtendimentoApplication.Abstractions.Repository;
using AtendimentoDomain.Entities;
using AtendimentoInfra.Context;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoInfra.Repositories
{
    public sealed class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Login(User user, CancellationToken cancellationToken)
        {
            User? requestedUser = await _context.Users
                .SingleOrDefaultAsync
                (
                    u => u.Username.ToLower() == user.Username.ToLower() && 
                    u.Password.ToLower() == user.Password.ToLower(),
                    cancellationToken
                );

            if (requestedUser is null)
                return null;

            return requestedUser;
        }
    }
}
