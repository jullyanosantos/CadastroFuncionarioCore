using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FuncionarioContext context)
        {
            if (context.Funcionarios.Any())
            {
                return;
            }

            var funcionarios = new Domain.Entities.Funcionario[]
             {
                 new Domain.Entities.Funcionario{ Id= 1, Nascimento = new DateTime(1991, 12, 01), Nome = "Daniel", Salario = 10.000M},
                 new Domain.Entities.Funcionario{ Id= 2, Nascimento = new DateTime(1980, 12, 01), Nome = "Sara", Salario = 10.000M},
                 new Domain.Entities.Funcionario{ Id= 3, Nascimento = new DateTime(1985, 12, 01), Nome = "Miguel", Salario = 10.000M},
             };

            foreach (var item in funcionarios)
            {
                context.Add(item);
            }

            context.SaveChanges();
        }
    }
}