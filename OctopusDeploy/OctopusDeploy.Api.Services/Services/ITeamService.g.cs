using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface ITeamService
	{
		Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model);

		Task<UpdateResponse<ApiTeamResponseModel>> Update(string id,
		                                                   ApiTeamRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiTeamResponseModel> Get(string id);

		Task<List<ApiTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiTeamResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>2ed1fccebb462269260a2acc513f8e01</Hash>
</Codenesium>*/