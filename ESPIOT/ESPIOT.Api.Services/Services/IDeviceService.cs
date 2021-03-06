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

		Task<List<ApiDeviceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiDeviceServerResponseModel> ByPublicId(Guid publicId);

		Task<List<ApiDeviceActionServerResponseModel>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c04af4404ca20b517f6c77ea31bd27a0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/