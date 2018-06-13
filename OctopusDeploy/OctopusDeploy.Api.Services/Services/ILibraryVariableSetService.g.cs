using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ILibraryVariableSetService
        {
                Task<CreateResponse<ApiLibraryVariableSetResponseModel>> Create(
                        ApiLibraryVariableSetRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiLibraryVariableSetRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiLibraryVariableSetResponseModel> Get(string id);

                Task<List<ApiLibraryVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiLibraryVariableSetResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>77f221655546485f7b2a79f8df2c6b89</Hash>
</Codenesium>*/