using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOMachineRefTeam
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
    <Hash>b6dca42be468c034a9e020c220d28de4</Hash>
</Codenesium>*/