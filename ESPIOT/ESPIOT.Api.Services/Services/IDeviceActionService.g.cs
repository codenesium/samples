using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public interface IDeviceActionService
	{
		Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model);

		Task<UpdateResponse<ApiDeviceActionResponseModel>> Update(int id,
		                                                           ApiDeviceActionRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceActionResponseModel> Get(int id);

		Task<List<ApiDeviceActionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeviceActionResponseModel>> ByDeviceId(int deviceId);
	}
}

/*<Codenesium>
    <Hash>8bd9e3b09e57e0ce0fbad7255b184b62</Hash>
</Codenesium>*/