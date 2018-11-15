using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDocumentService
	{
		Task<CreateResponse<ApiDocumentServerResponseModel>> Create(
			ApiDocumentServerRequestModel model);

		Task<UpdateResponse<ApiDocumentServerResponseModel>> Update(Guid rowguid,
		                                                             ApiDocumentServerRequestModel model);

		Task<ActionResponse> Delete(Guid rowguid);

		Task<ApiDocumentServerResponseModel> Get(Guid rowguid);

		Task<List<ApiDocumentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiDocumentServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiDocumentServerResponseModel>> ByFileNameRevision(string fileName, string revision, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ba02fe8d2f7c074af52dce27f1765a04</Hash>
</Codenesium>*/