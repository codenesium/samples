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

                Task<List<ProductInventory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3b9a27d8d1c7eade362e347fd74d34d7</Hash>
</Codenesium>*/