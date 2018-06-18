using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IShoppingCartItemRepository
        {
                Task<ShoppingCartItem> Create(ShoppingCartItem item);

                Task Update(ShoppingCartItem item);

                Task Delete(int shoppingCartItemID);

                Task<ShoppingCartItem> Get(int shoppingCartItemID);

                Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ShoppingCartItem>> ByShoppingCartIDProductID(string shoppingCartID, int productID);
        }
}

/*<Codenesium>
    <Hash>bfd305524ced46fc9667f3e112a3ad8b</Hash>
</Codenesium>*/