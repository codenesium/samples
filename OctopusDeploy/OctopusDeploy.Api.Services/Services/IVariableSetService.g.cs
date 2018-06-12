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

                Task<List<ApiVariableSetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fc14ace2c287ec98cedff282a7f39f75</Hash>
</Codenesium>*/