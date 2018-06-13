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

                Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<ShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID, int productID);
        }
}

/*<Codenesium>
    <Hash>1144412fe9048929bedfecf4d71022be</Hash>
</Codenesium>*/