using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		int Create(ProductInventoryModel model);

		void Update(int productID,
		            ProductInventoryModel model);

		void Delete(int productID);

		POCOProductInventory Get(int productID);

		List<POCOProductInventory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>523e2dcfccb8289ba21e8c1ab1342812</Hash>
</Codenesium>*/