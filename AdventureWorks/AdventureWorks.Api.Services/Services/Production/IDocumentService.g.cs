using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDocumentService
	{
		Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model);

		Task<UpdateResponse<ApiDocumentResponseModel>> Update(Guid rowguid,
		                                                       ApiDocumentRequestModel model);

		Task<ActionResponse> Delete(Guid rowguid);

		Task<ApiDocumentResponseModel> Get(Guid rowguid);

		Task<List<ApiDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDocumentResponseModel>> ByFileNameRevision(string fileName, string revision, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDocumentResponseModel>> ByProductID(int documentNode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f6cd8e10149e3c23d1bb45ec6d543c5f</Hash>
</Codenesium>*/