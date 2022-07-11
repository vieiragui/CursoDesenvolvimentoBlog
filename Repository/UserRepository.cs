using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoDesenvolvimentoWeb.Context;
using CursoDesenvolvimentoWeb.Models;
using CursoDesenvolvimentoWeb.Repository.Base;
using CursoDesenvolvimentoWeb.Repository.Interfaces;

namespace CursoDesenvolvimentoWeb.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context)
        {
        }
    }
}