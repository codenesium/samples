using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IMachineRefTeamService
        {
                Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
                        ApiMachineRefTeamRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiMachineRefTeamRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiMachineRefTeamResponseModel> Get(int id);

                Task<List<ApiMachineRefTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>0816e57a206ed11e28448fd7488f5e31</Hash>
</Codenesium>*/