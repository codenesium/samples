using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IDeviceActionService
	{
		Task<CreateResponse<ApiDeviceActionServerResponseModel>> Create(
			ApiDeviceActionServerRequestModel model);

		Task<UpdateResponse<ApiDeviceActionServerResponseModel>> Update(int id,
		                                                                 ApiDeviceActionServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDeviceActionServerResponseModel> Get(int id);

		Task<List<ApiDeviceActionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiDeviceActionServerResponseModel>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6cda01dd9e252593e20b7e5c0ed6c170</Hash>
</Codenesium>*/