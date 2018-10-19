using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Nascimento { get; set; }

        public string Salario { get; set; }

        public int Ativo { get; set; }
    }
}