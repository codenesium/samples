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

		Task<POCOProductInventory> Get(int productID);

		Task<List<POCOProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1a44e9f30288bae45609324f528b142a</Hash>
</Codenesium>*/