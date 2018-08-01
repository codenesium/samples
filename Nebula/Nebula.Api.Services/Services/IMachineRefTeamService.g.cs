using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IMachineRefTeamService
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
    <Hash>cee8817d97edcd1081d953e29ffd4ca2</Hash>
</Codenesium>*/