using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>f6908936e370b3b365115ee95a924b99</Hash>
</Codenesium>*/