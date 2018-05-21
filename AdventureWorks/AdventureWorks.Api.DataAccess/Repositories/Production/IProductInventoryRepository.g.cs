using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		Task<POCOProductInventory> Create(ApiProductInventoryModel model);

		Task Update(int productID,
		            ApiProductInventoryModel model);

		Task Delete(int productID);

		Task<POCOProductInventory> Get(int productID);

		Task<List<POCOProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e581d5ede5fd6a51f490894f524f6d7d</Hash>
</Codenesium>*/