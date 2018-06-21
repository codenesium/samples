using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IMachineService
        {
                Task<CreateResponse<ApiMachineResponseModel>> Create(
                        ApiMachineRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiMachineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiMachineResponseModel> Get(int id);

                Task<List<ApiMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLinkResponseModel>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1c2625cd5e8629c917d7877fe96f6c5b</Hash>
</Codenesium>*/