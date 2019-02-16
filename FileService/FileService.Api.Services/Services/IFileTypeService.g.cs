using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IFileTypeService
	{
		Task<CreateResponse<ApiFileTypeServerResponseModel>> Create(
			ApiFileTypeServerRequestModel model);

		Task<UpdateResponse<ApiFileTypeServerResponseModel>> Update(int id,
		                                                             ApiFileTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFileTypeServerResponseModel> Get(int id);

		Task<List<ApiFileTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiFileServerResponseModel>> FilesByFileTypeId(int fileTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3cadff27a8c1315c19d604818d526da7</Hash>
</Codenesium>*/