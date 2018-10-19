using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/funcionario")]
    public class FuncionarioController : Controller
    {
        #region Attributes
        private readonly IFuncionarioApplication _funcionarioApplication;

        #endregion

        #region Constructors
        public FuncionarioController(IFuncionarioApplication funcionarioApplication)
        {
            _funcionarioApplication = funcionarioApplication;
        }
        #endregion

        #region Public Methods
        public BaseResult Get([FromBody] FuncionarioViewModel funcionario)
        {
            try
            {
                var funcionarios = _funcionarioApplication.GetAll(funcionario);

                if (funcionarios.Any())
                {
                    var result = new BaseResult
                    {
                        Success = true,
                        Object = funcionarios
                    };

                    return result;
                }

                var msg = "Não existem dados com essa pesquisa.";

                return new BaseResult
                {
                    Message = msg
                };
            }
            catch (Exception ex)
            {
                return new BaseResult
                {
                    Message = "Error, tente novamente."
                };
            }
        }
        #endregion

        [Route("list-all")]
        [HttpGet]
        public IEnumerable<FuncionarioViewModel> Get()
        {
            var result = _funcionarioApplication.GetAll();

            return result;
        }

        [HttpGet("get-func/{id}")]
        public FuncionarioViewModel Get(int id)
        {
            var funcionario = _funcionarioApplication.GetAll(new FuncionarioViewModel { Id = id });

            return funcionario.FirstOrDefault();
        }

        [HttpPost("save-func/")]
        public int Post([FromBody]FuncionarioViewModel funcionario)
        {
            return _funcionarioApplication.Add(funcionario);
        }

        [HttpPut("update-func/")]
        public int Put([FromBody]FuncionarioViewModel funcionario)
        {
           return _funcionarioApplication.Update(funcionario);
        }

        [HttpDelete("delete-func/{id}")]
        public int Delete(int id)
        {
            return _funcionarioApplication.Delete(id);
        }
    }
}