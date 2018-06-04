using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductDescriptionService
	{
		Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model);

		Task<ActionResponse> Update(int productDescriptionID,
		                            ApiProductDescriptionRequestModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID);

		Task<List<ApiProductDescriptionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>389731d1134a0eaeac2b1e1032e1390b</Hash>
</Codenesium>*/