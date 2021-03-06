﻿using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Data.Entity;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalRepositorioSql : INotaFiscalRepositorio
    {
        ProjetoNFeContexto _contexto;

        public NotaFiscalRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }

        public long Adicionar(NotaFiscal notaFiscal)
        {
            notaFiscal = _contexto.NotasFiscais.Add(notaFiscal);
            _contexto.SaveChanges();
            return notaFiscal.Id;
        }

        public bool Atualizar(NotaFiscal notaFiscal)
        {
            return _contexto.SaveChanges() != 0;
        }

        public NotaFiscal BuscarPorId(long Id)
        {
            NotaFiscal notaFiscal = _contexto.NotasFiscais.Where(x => x.Id == Id).Include("Produtos").FirstOrDefault();

            return notaFiscal;
        }

        public IQueryable<NotaFiscal> BuscarTodos()
        {
            return _contexto.NotasFiscais.Include("Transportador").Include("Emitente").Include("Destinatario");
        }

        public bool Excluir(NotaFiscal notaFiscal)
        {
            _contexto.NotasFiscais.Remove(notaFiscal);

            ProdutoNotaFiscalRepositorioSql produtoNotaFiscalRepositorio = new ProdutoNotaFiscalRepositorioSql(_contexto);

            return _contexto.SaveChanges() != 0;
        }
    }
}
