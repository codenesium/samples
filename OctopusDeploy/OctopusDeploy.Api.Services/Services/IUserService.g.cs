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

                Task<ApiUserResponseModel> GetUsername(string username);

                Task<List<ApiUserResponseModel>> GetDisplayName(string displayName);

                Task<List<ApiUserResponseModel>> GetEmailAddress(string emailAddress);

                Task<List<ApiUserResponseModel>> GetExternalId(string externalId);
        }
}

/*<Codenesium>
    <Hash>4830f42010b0f4b3851307803a3c558c</Hash>
</Codenesium>*/