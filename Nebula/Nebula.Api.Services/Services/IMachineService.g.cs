using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IMachineService
	{
		Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model);

		Task<UpdateResponse<ApiMachineResponseModel>> Update(int id,
		                                                      ApiMachineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineResponseModel> Get(int id);

		Task<List<ApiMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkResponseModel>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>edc6e083c3dedb483c3b7209dbf779f7</Hash>
</Codenesium>*/