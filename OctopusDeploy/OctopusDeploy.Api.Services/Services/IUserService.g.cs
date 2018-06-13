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

                Task<List<ApiUserResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiUserResponseModel> GetUsername(string username);
                Task<List<ApiUserResponseModel>> GetDisplayName(string displayName);
                Task<List<ApiUserResponseModel>> GetEmailAddress(string emailAddress);
                Task<List<ApiUserResponseModel>> GetExternalId(string externalId);
        }
}

/*<Codenesium>
    <Hash>e57264622ea2332bba6f786a3f20faa6</Hash>
</Codenesium>*/