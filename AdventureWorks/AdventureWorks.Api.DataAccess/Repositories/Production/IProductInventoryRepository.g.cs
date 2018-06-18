using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductInventoryRepository
        {
                Task<ProductInventory> Create(ProductInventory item);

                Task Update(ProductInventory item);

                Task Delete(int productID);

                Task<ProductInventory> Get(int productID);

                Task<List<ProductInventory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7fe352d7c9252d3bdd007c8e7c3d9576</Hash>
</Codenesium>*/