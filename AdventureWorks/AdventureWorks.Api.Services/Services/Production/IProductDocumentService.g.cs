using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductDocumentService
	{
		Task<CreateResponse<ApiProductDocumentResponseModel>> Create(
			ApiProductDocumentRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductDocumentRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductDocumentResponseModel> Get(int productID);

		Task<List<ApiProductDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>84b80bdfe9e824d288c90be89e06bc9f</Hash>
</Codenesium>*/