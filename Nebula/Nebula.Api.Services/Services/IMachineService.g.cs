using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IMachineService
	{
		Task<CreateResponse<ApiMachineServerResponseModel>> Create(
			ApiMachineServerRequestModel model);

		Task<UpdateResponse<ApiMachineServerResponseModel>> Update(int id,
		                                                            ApiMachineServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineServerResponseModel> Get(int id);

		Task<List<ApiMachineServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiMachineServerResponseModel> ByMachineGuid(Guid machineGuid);

		Task<List<ApiLinkServerResponseModel>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMachineRefTeamServerResponseModel>> MachineRefTeamsByMachineId(int machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d1f7a5c701589158aed02f3621490230</Hash>
</Codenesium>*/