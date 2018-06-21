using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>fb39d82d23abbbf49e1ed730166283c2</Hash>
</Codenesium>*/