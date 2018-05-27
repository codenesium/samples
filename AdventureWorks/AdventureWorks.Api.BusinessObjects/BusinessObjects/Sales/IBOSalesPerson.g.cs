using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesPerson
	{
		Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
			ApiSalesPersonRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesPersonRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesPersonResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6944858dd2404add56b1f9d6e98b3f6b</Hash>
</Codenesium>*/