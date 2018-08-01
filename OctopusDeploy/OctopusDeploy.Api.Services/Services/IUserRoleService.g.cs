using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IUserRoleService
	{
		Task<CreateResponse<ApiUserRoleResponseModel>> Create(
			ApiUserRoleRequestModel model);

		Task<UpdateResponse<ApiUserRoleResponseModel>> Update(string id,
		                                                       ApiUserRoleRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiUserRoleResponseModel> Get(string id);

		Task<List<ApiUserRoleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiUserRoleResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>45d3d1dc8a2e6357750ec737d5893641</Hash>
</Codenesium>*/