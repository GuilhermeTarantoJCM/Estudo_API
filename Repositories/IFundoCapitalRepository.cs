using System;
using System.Collections.Generic;
using AulaAPI.Models;

namespace AulaAPI.Repositories
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundo);
        void Alterar(FundoCapital fundo);
        IEnumerable<FundoCapital> ListarFundos();
        FundoCapital ObterporId(Guid id);
        void RemoverFundo(FundoCapital fundo);
    }
}