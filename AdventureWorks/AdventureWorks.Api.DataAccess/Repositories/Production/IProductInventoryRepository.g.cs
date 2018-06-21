using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>04c3db4b43ce09635f8e93f67444f96d</Hash>
</Codenesium>*/