using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductInventory
	{
		Task<CreateResponse<int>> Create(
			ProductInventoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductInventoryModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductInventory Get(int productID);

		List<POCOProductInventory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0be3c2bdd26c0b3754b2f0b27b143012</Hash>
</Codenesium>*/