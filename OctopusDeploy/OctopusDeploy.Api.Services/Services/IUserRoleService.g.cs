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

                Task<ActionResponse> Update(string id,
                                            ApiUserRoleRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiUserRoleResponseModel> Get(string id);

                Task<List<ApiUserRoleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiUserRoleResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>074bea937ab51c5223fa41a5497e1f80</Hash>
</Codenesium>*/