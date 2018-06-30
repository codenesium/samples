using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IVariableSetService
        {
                Task<CreateResponse<ApiVariableSetResponseModel>> Create(
                        ApiVariableSetRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiVariableSetRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiVariableSetResponseModel> Get(string id);

                Task<List<ApiVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1c32f025eef5ca8fa5738e62ff4fdcea</Hash>
</Codenesium>*/