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

		Task<List<ApiDeviceActionResponseModel>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a6ce6003760f8e9ffd71acda8406fb60</Hash>
</Codenesium>*/