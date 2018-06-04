using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface IMachineRefTeamService
	{
		Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
			ApiMachineRefTeamRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiMachineRefTeamRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineRefTeamResponseModel> Get(int id);

		Task<List<ApiMachineRefTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>682c04fae2f27593d50d1b77b02a3447</Hash>
</Codenesium>*/