using System.Linq;
using System.Collections.Generic;
using Domain.Contracts.Repository;
using Domain.Entities;
using System;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;

namespace Application.Services
{
    public class FuncionarioApplication : IFuncionarioApplication
    {
        #region Attributes
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public FuncionarioApplication(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        public IEnumerable<FuncionarioViewModel> GetAll()
        {
            var funcionarios = _funcionarioRepository.GetAll().ToList();

            var lstFuncionario = new List<FuncionarioViewModel>();

            foreach (var item in funcionarios)
            {
                lstFuncionario.Add(Mapper<Funcionario, FuncionarioViewModel>.CreateMapper(item));
            }
            return lstFuncionario;
        }

        public IEnumerable<FuncionarioViewModel> GetAll(FuncionarioViewModel funcionario)
        {
            var query = _funcionarioRepository.GetAll();

            if (funcionario != null)
            {
                if (funcionario.Id > 0)
                    query = query.Where(x => x.Id == funcionario.Id);

                if (!string.IsNullOrEmpty(funcionario.Nome))
                    query = query.Where(x => x.Nome.Trim().ToUpper().Contains(funcionario.Nome.Trim().ToUpper()));
            }

            var result = new List<FuncionarioViewModel>();

            var funcionarios = query.ToList();

            if (funcionarios.Any())
            {
                foreach (var item in funcionarios)
                {
                    result.Add(Mapper<Funcionario, FuncionarioViewModel>.CreateMapper(item));
                }
            }

            return result;
        }

        public int Add(FuncionarioViewModel FuncionarioViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(FuncionarioViewModel);
            
            if (FuncionarioViewModel.Id == 0)
            {
                _funcionarioRepository.Add(funcionario);
            }

            return funcionario.Id;
        }

        public int Update(FuncionarioViewModel FuncionarioViewModel)
        {
            var funcionario = Mapper<FuncionarioViewModel, Funcionario>.CreateMapper(FuncionarioViewModel);

            _funcionarioRepository.Update(funcionario);

            return funcionario.Id;
        }

        public int Delete(int id)
        {
            return _funcionarioRepository.Delete(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}