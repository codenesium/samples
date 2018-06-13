using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface ITeamService
        {
                Task<CreateResponse<ApiTeamResponseModel>> Create(
                        ApiTeamRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTeamRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeamResponseModel> Get(int id);

                Task<List<ApiTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiChainResponseModel>> Chains(int teamId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int teamId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>460d6ed2d58b42975721d1d9688735f3</Hash>
</Codenesium>*/