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

                Task<List<ApiUserRoleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiUserRoleResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>1547c4131ce13b605e50d8c8a0937c4b</Hash>
</Codenesium>*/