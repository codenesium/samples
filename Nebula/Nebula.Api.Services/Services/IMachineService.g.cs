using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>80a40b05ce6d07e192f5efe2829e02f6</Hash>
</Codenesium>*/