using AliBazar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.ViewModels
{
    public class CommentDTO
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public string Commentaria { get; set; }
    }
}
