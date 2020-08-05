using System;
using System.Collections.Generic;
using AulaAPI.Models;
using System.Linq;

namespace AulaAPI.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void Alterar(FundoCapital fundo)
        {
            var index = _storage.FindIndex(0, 1, x => x.Id == fundo.Id);
            _storage[index] = fundo;
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _storage;
        }

        public FundoCapital ObterporId(Guid id)
        {
            return _storage.FirstOrDefault(x => x.Id == id);
        }

        public void RemoverFundo(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }
    }
}