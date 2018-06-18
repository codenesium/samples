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

                Task<List<ApiLibraryVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiLibraryVariableSetResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>6eb8cd958d722389ed1cb2a8a064b364</Hash>
</Codenesium>*/