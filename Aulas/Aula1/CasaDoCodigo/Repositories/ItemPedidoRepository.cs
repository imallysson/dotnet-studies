using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        void UpdateQuantidade(ItemPedido itemPedido);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemDB = dbSet
                            .Where(x => x.Id == itemPedido.Id)
                            .SingleOrDefault();

            if (null != itemDB)
            {
                itemDB.AtualizaQuantidade(itemPedido.Quantidade);

                context.SaveChanges();
            }
        }
    }
}
