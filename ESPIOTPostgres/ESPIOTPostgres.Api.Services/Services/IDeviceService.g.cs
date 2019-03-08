using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IDeviceService
	{
		Task<CreateResponse<ApiDeviceServerResponseModel>> Create(
			ApiDeviceServerRequestModel model);

		Task<UpdateResponse<ApiDeviceServerResponseModel>> Update(int id,
		                                                           ApiDeviceServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceServerResponseModel> Get(int id);

		Task<List<ApiDeviceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiDeviceServerResponseModel> ByPublicId(Guid publicId);

		Task<List<ApiDeviceActionServerResponseModel>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9f6239f4627abf1e7dfcaa62e79a9ee8</Hash>
</Codenesium>*/