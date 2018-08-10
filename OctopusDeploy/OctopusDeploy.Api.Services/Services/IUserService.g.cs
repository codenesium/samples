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

		Task<List<ApiUserResponseModel>> ByDisplayName(string displayName);

		Task<List<ApiUserResponseModel>> ByEmailAddress(string emailAddress);

		Task<List<ApiUserResponseModel>> ByExternalId(string externalId);
	}
}

/*<Codenesium>
    <Hash>bca28e46cff5632a0f89c3c37639fd43</Hash>
</Codenesium>*/