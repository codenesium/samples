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

		Task<List<ApiDocumentResponseModel>> ByFileNameRevision(string fileName, string revision);
	}
}

/*<Codenesium>
    <Hash>f7cff7f6b1a98f0c6e119acbb0836748</Hash>
</Codenesium>*/