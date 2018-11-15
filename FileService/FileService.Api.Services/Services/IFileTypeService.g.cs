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

		Task<List<ApiFileTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFileServerResponseModel>> FilesByFileTypeId(int fileTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>97c0c7558f7d671e06d06271077e6fe9</Hash>
</Codenesium>*/