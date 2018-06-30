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

                Task<ActionResponse> Update(string id,
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
    <Hash>50677c91fbacb6d2383ceceec00847fa</Hash>
</Codenesium>*/