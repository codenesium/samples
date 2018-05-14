using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		POCOProductInventory Create(ApiProductInventoryModel model);

		void Update(int productID,
		            ApiProductInventoryModel model);

		void Delete(int productID);

		POCOProductInventory Get(int productID);

		List<POCOProductInventory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c9e7581966ad9067558d248e7ab0454e</Hash>
</Codenesium>*/