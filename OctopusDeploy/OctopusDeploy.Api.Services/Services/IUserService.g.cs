using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiUserResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiUserResponseModel> GetUsername(string username);
                Task<List<ApiUserResponseModel>> GetDisplayName(string displayName);
                Task<List<ApiUserResponseModel>> GetEmailAddress(string emailAddress);
                Task<List<ApiUserResponseModel>> GetExternalId(string externalId);
        }
}

/*<Codenesium>
    <Hash>002d6e6c831594e825843f581e4aa9ab</Hash>
</Codenesium>*/