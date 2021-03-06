﻿using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Data.Entity;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras
{
    public class TransportadorRepositorioSql : ITransportadorRepositorio
    {
        ProjetoNFeContexto _contexto;

        public TransportadorRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }

        public long Adicionar(Transportador transportador)
        {
            transportador = _contexto.Transportadoras.Add(transportador);
            _contexto.SaveChanges();

            return transportador.Id;
        }

        public bool Atualizar(Transportador transportador)
        {
            return _contexto.SaveChanges() != 0;
        }

        public Transportador BuscarPorId(long Id)
        {
            Transportador transportador = _contexto.Transportadoras.Where(x => x.Id == Id).Include("Endereco").Include("Documento").FirstOrDefault();

            return transportador;
        }

        public IQueryable<Transportador> BuscarTodos()
        {
            return _contexto.Transportadoras.Include("Endereco").Include("Documento");
        }

        public bool Excluir(Transportador transportador)
        {
            _contexto.Transportadoras.Remove(transportador);
            return _contexto.SaveChanges() != 0;
        }
    }
}
