﻿using AliBazar.Application.Abstractions;
using AliBazar.Domain.Entities;
using AliBazar.Infrastructure.Persistance;

namespace AliBazar.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AliBazarDbContext context)
            : base(context)
        {
        }
    }
}
