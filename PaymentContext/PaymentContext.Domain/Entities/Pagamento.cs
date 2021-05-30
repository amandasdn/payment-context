﻿using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Pagamento
    {
        protected Pagamento(
            DateTime dataPagamento,
            DateTime dataExpiracao,
            decimal valor,
            decimal valorPagamento,
            string proprietario,
            Documento documento,
            Email email,
            Endereco endereco)
        {
            Id = Guid.NewGuid().ToString().ToUpper().Replace("-","");
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Valor = valor;
            ValorPagamento = valorPagamento;
            Proprietario = proprietario;
            Documento = documento;
            Email = email;
            Endereco = endereco;
        }

        public string Id { get; private set; }

        public DateTime DataPagamento { get; private set; }

        public DateTime DataExpiracao { get; private set; }

        /// <summary>
        /// Valor total.
        /// </summary>
        public decimal Valor { get; private set; }

        /// <summary>
        /// Valor do pagamento.
        /// </summary>
        public decimal ValorPagamento { get; private set; }

        /// <summary>
        /// Quem irá realizar o pagamento.
        /// </summary>
        public string Proprietario { get; private set; }

        public Documento Documento { get; private set; }

        public Email Email { get; private set; }

        public Endereco Endereco { get; private set; }
    }
}
