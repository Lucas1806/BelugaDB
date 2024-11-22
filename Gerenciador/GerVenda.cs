using System.Collections.Generic;

namespace ConsoleApp1.Entidades
{
    public class GerVenda
    {

        private int IdCounter = 0;
        private readonly Dictionary<int, Venda> vendas = [];
        public bool Remover(int id) => vendas.Remove(id);
        public bool AdicionarItem(Produto produto, int quantidade, int vendaId)
        {
            if (vendas.TryGetValue(vendaId, out Venda? venda))
            {
                IdCounter++;
                ProdutoVenda produtoVenda = new(produto, quantidade);
                if (venda.Produtos.TryAdd(IdCounter, produtoVenda))
                {
                    return true;
                }
            }
            return false;
        }
        public int? Cadastro(Dictionary<int, ProdutoVenda> produtos, int clienteId, int vendedorId)
        {
            IdCounter++;
            Venda venda = new(IdCounter, produtos, clienteId, vendedorId);
            if (vendas.TryAdd(IdCounter, venda))
            {
                return IdCounter;
            }
            return null;
        }
        public Dictionary<int, Venda> GetAll() => vendas;
        public Venda? GetById(int id) => vendas.TryGetValue(id, out Venda? venda) ? venda : null;
    }
}
