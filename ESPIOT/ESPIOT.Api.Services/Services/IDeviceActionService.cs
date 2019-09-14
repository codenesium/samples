using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
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
    <Hash>b44da246f94cf2bf9fa0ae0fee304139</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/