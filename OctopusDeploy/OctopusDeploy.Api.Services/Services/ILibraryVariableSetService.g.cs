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

                Task<List<ApiLibraryVariableSetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiLibraryVariableSetResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>b9648c7c3d6cd4667d30280d6611937d</Hash>
</Codenesium>*/