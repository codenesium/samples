using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IMachineRefTeamService
	{
		Task<CreateResponse<ApiMachineRefTeamServerResponseModel>> Create(
			ApiMachineRefTeamServerRequestModel model);

		Task<UpdateResponse<ApiMachineRefTeamServerResponseModel>> Update(int id,
		                                                                   ApiMachineRefTeamServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineRefTeamServerResponseModel> Get(int id);

		Task<List<ApiMachineRefTeamServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>9b54de09e22906b0f38a0d1cefefdc11</Hash>
</Codenesium>*/