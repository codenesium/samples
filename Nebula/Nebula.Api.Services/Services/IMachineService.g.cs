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

		Task<ApiMachineResponseModel> ByMachineGuid(Guid machineGuid);

		Task<List<ApiLinkResponseModel>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMachineResponseModel>> ByTeamId(int machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>82102f0b4c1d8f06a2368ce597618daa</Hash>
</Codenesium>*/