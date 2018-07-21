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

                Task<UpdateResponse<ApiLibraryVariableSetResponseModel>> Update(string id,
                                                                                 ApiLibraryVariableSetRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiLibraryVariableSetResponseModel> Get(string id);

                Task<List<ApiLibraryVariableSetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiLibraryVariableSetResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>b0ee3e229f0f948a890020eab73867ba</Hash>
</Codenesium>*/