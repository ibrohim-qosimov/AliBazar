using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.CommentServices
{
    public interface ICommnetService
    {
        public Task<ResponseModel> CreateComment(CommentDTO commentDTO);
        public Task<bool> DeleteCommentById(long id);
        public Task<IEnumerable<Comment>> GetCommentsByProductId(long id);
        public Task<IEnumerable<Comment>> GetCommentsByUserId(long id);
        public Task<IEnumerable<Comment>> GetAllComments();
    }
}
