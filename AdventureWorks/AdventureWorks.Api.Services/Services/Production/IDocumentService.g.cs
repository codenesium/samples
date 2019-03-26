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

		Task<List<ApiDocumentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiDocumentServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiDocumentServerResponseModel>> ByFileNameRevision(string fileName, string revision, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2ac74f045495d37c039d399119d19ecf</Hash>
</Codenesium>*/