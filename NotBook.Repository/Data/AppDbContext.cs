using Microsoft.EntityFrameworkCore;
using NotBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionMember> SessionMembers { get; set; }

    }
}
