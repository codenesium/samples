using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IEfmigrationshistoryService
	{
		Task<CreateResponse<ApiEfmigrationshistoryServerResponseModel>> Create(
			ApiEfmigrationshistoryServerRequestModel model);

		Task<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>> Update(string migrationId,
		                                                                        ApiEfmigrationshistoryServerRequestModel model);

		Task<ActionResponse> Delete(string migrationId);

		Task<ApiEfmigrationshistoryServerResponseModel> Get(string migrationId);

		Task<List<ApiEfmigrationshistoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5c029a835372e842cb484aa0132fdef0</Hash>
</Codenesium>*/