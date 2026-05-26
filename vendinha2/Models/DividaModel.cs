using System;

namespace vendinha2.Models
{
        public class DividaModel
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public double Valor { get; set; }

        public string Situacao { get; set; } = "";

        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }
    }
}