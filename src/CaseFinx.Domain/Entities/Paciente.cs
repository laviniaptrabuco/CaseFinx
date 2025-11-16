using System;
using System.Collections.Generic;
using System.Text;

namespace CaseFinx.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Contato { get; set; }

        public Paciente(string id, string nome, string cpf, DateTime dataNascimento, string contato)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Contato = contato;
        }
    }
}
