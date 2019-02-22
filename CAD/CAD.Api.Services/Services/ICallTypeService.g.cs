using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallTypeService
	{
		Task<CreateResponse<ApiCallTypeServerResponseModel>> Create(
			ApiCallTypeServerRequestModel model);

		Task<UpdateResponse<ApiCallTypeServerResponseModel>> Update(int id,
		                                                             ApiCallTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallTypeServerResponseModel> Get(int id);

		Task<List<ApiCallTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallServerResponseModel>> CallsByCallTypeId(int callTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>29d2c2711484967f5d8b0b0b90a8e998</Hash>
</Codenesium>*/