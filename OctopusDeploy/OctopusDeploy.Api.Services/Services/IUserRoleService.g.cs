using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiUserRoleResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiUserRoleResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>fed28a4cd8d65273bbd88221d64026d6</Hash>
</Codenesium>*/