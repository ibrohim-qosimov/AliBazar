using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace AliBazar.Application.Services.CommentServices
{
    public class CommentService : ICommnetService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CommentService(ICommentRepository commentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _commentRepository = commentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> CreateComment(CommentDTO commentDTO)
        {
            var comment = new Comment()
            {
                ProductId = commentDTO.ProductId,
                UserId = commentDTO.UserId,
                Commentaria = commentDTO.Commentaria
            };

            var result = await _commentRepository.Create(comment);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "Comment created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteCommentById(long id)
        {
            var deleteCommentResult = await _commentRepository.Delete(x => x.Id == id);

            return deleteCommentResult;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentRepository.GetAll();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByProductId(long id)
        {
            var commentResult = await _commentRepository.GetAll();
            var comments = commentResult.Where(x => x.ProductId == id);
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserId(long id)
        {
            var commentResult = await _commentRepository.GetAll();
            var comments = commentResult.Where(x => x.UserId == id);
            return comments;
        }
    }
}
