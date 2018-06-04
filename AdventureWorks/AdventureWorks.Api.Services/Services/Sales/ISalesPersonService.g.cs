using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesPersonService
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
    <Hash>e44ac57babd619f4bc0e197d07373fc2</Hash>
</Codenesium>*/