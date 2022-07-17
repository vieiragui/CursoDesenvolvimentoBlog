using CursoDesenvolvimentoWeb.Context;
using CursoDesenvolvimentoWeb.Models;
using CursoDesenvolvimentoWeb.Repository.Base;
using CursoDesenvolvimentoWeb.Repository.Interfaces;

namespace CursoDesenvolvimentoWeb.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context)
        {
        }
    }
}