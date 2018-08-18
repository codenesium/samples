using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model);

		Task<UpdateResponse<ApiUserResponseModel>> Update(string id,
		                                                   ApiUserRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiUserResponseModel> Get(string id);

		Task<List<ApiUserResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiUserResponseModel> ByUsername(string username);

		Task<List<ApiUserResponseModel>> ByDisplayName(string displayName, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> ByEmailAddress(string emailAddress, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> ByExternalId(string externalId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>22c40ec752e2fb8755904909f9d3d8c8</Hash>
</Codenesium>*/