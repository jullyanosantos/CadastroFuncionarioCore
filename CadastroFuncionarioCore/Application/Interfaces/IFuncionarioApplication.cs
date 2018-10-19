using Application.ViewModels;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IFuncionarioApplication : IDisposable
    {
        IEnumerable<FuncionarioViewModel> GetAll(FuncionarioViewModel funcionario);
        IEnumerable<FuncionarioViewModel> GetAll();
        int Add(FuncionarioViewModel funcionario);
        int Update(FuncionarioViewModel funcionario);
        int Delete(int id);
    }
}