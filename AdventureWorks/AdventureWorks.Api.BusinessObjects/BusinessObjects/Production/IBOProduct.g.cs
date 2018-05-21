using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProduct
	{
		Task<CreateResponse<POCOProduct>> Create(
			ApiProductModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductModel model);

		Task<ActionResponse> Delete(int productID);

		Task<POCOProduct> Get(int productID);

		Task<List<POCOProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProduct> GetName(string name);
		Task<POCOProduct> GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>1439556930ab3d02a341fff8e669596b</Hash>
</Codenesium>*/