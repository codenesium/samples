using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IMachineRefTeamService
	{
		Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
			ApiMachineRefTeamRequestModel model);

		Task<UpdateResponse<ApiMachineRefTeamResponseModel>> Update(int id,
		                                                             ApiMachineRefTeamRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineRefTeamResponseModel> Get(int id);

		Task<List<ApiMachineRefTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>daf30388039377b5518fd06711ec1b28</Hash>
</Codenesium>*/