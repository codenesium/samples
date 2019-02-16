using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IFileService
	{
		Task<CreateResponse<ApiFileServerResponseModel>> Create(
			ApiFileServerRequestModel model);

		Task<UpdateResponse<ApiFileServerResponseModel>> Update(int id,
		                                                         ApiFileServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFileServerResponseModel> Get(int id);

		Task<List<ApiFileServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>b5eee1cd33615eb9612ab3b25bb6c21e</Hash>
</Codenesium>*/