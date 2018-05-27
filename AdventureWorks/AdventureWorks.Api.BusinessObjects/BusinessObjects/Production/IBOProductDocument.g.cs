using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductDocument
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
    <Hash>30a67987e984d4b87ffe3a6a465e7aad</Hash>
</Codenesium>*/