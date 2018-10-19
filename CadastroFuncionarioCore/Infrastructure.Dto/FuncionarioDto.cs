using System;

namespace Infrastructure.Dto
{
    public class FuncionarioDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public decimal Salario { get; set; }
    }
}