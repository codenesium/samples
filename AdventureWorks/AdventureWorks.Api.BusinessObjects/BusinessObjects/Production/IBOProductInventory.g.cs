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
		Task<CreateResponse<POCOProductInventory>> Create(
			ApiProductInventoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductInventoryModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductInventory Get(int productID);

		List<POCOProductInventory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c1a4610423d23ebe8e9a4c5ddaa89bd3</Hash>
</Codenesium>*/