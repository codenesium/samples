using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDeviceService
	{
		Task<CreateResponse<ApiDeviceServerResponseModel>> Create(
			ApiDeviceServerRequestModel model);

		Task<UpdateResponse<ApiDeviceServerResponseModel>> Update(int id,
		                                                           ApiDeviceServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceServerResponseModel> Get(int id);

		Task<List<ApiDeviceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiDeviceServerResponseModel> ByPublicId(Guid publicId);

		Task<List<ApiDeviceActionServerResponseModel>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4989b3565cbd6a4baa1d8c37ec6457a3</Hash>
</Codenesium>*/