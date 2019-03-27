using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ITeamService
	{
		Task<CreateResponse<ApiTeamServerResponseModel>> Create(
			ApiTeamServerRequestModel model);

		Task<UpdateResponse<ApiTeamServerResponseModel>> Update(int id,
		                                                         ApiTeamServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeamServerResponseModel> Get(int id);

		Task<List<ApiTeamServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiTeamServerResponseModel> ByName(string name);

		Task<List<ApiChainServerResponseModel>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMachineRefTeamServerResponseModel>> MachineRefTeamsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>378bc3be6a5fd789e762810e49f6818e</Hash>
</Codenesium>*/