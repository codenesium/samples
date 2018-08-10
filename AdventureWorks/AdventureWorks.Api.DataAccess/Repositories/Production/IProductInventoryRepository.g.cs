using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductInventoryRepository
	{
		Task<ProductInventory> Create(ProductInventory item);

		Task Update(ProductInventory item);

		Task Delete(int productID);

		Task<ProductInventory> Get(int productID);

		Task<List<ProductInventory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1122008671d25890b15be77b5221bd13</Hash>
</Codenesium>*/