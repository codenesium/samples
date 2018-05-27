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
		Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductResponseModel> Get(int productID);

		Task<List<ApiProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiProductResponseModel> GetName(string name);
		Task<ApiProductResponseModel> GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>87a3fb991a24287c0ae106987cf2e320</Hash>
</Codenesium>*/