using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IUserService
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
    <Hash>6cbcec5ee5ba52c08046075c6c43b57e</Hash>
</Codenesium>*/