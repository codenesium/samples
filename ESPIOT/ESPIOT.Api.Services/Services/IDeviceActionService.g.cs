using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDeviceActionService
	{
		Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model);

		Task<UpdateResponse<ApiDeviceActionResponseModel>> Update(int id,
		                                                           ApiDeviceActionRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceActionResponseModel> Get(int id);

		Task<List<ApiDeviceActionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeviceActionResponseModel>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1b6ba03c1966a23c16f84c8ef853f02e</Hash>
</Codenesium>*/