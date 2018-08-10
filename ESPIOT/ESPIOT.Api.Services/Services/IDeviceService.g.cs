using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDeviceService
	{
		Task<CreateResponse<ApiDeviceResponseModel>> Create(
			ApiDeviceRequestModel model);

		Task<UpdateResponse<ApiDeviceResponseModel>> Update(int id,
		                                                     ApiDeviceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceResponseModel> Get(int id);

		Task<List<ApiDeviceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiDeviceResponseModel> ByPublicId(Guid publicId);

		Task<List<ApiDeviceActionResponseModel>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8184ec7d0d36c00533f0310ff65d1330</Hash>
</Codenesium>*/