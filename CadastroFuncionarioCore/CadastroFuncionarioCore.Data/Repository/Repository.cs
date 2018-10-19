using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Contracts.Repository;
using Domain.Contracts.Entities;

namespace CadastroFuncionarioCore.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

    }
}
