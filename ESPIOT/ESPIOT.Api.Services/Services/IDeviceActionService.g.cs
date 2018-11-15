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

		Task<List<ApiDeviceActionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDeviceActionServerResponseModel>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>462a91422b616c1dd146bf1797f86583</Hash>
</Codenesium>*/