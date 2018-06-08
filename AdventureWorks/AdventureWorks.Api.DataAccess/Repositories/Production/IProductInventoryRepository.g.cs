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

                Task<List<ProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f4ccf238e117275620fb086d84f68cab</Hash>
</Codenesium>*/