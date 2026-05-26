using System;

namespace vendinha2.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; } = "";

        public string CPF { get; set; } = "";

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; } = "";

        // Idade calculada automaticamente
        public int Idade
        {
            get
            {
                int idade = DateTime.Now.Year - DataNascimento.Year;

                if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                {
                    idade--;
                }

                return idade;
            }
        }
    }
}