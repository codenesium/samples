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

                Task<List<ApiMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiLinkResponseModel>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fcbfe3bbfdd9c0cd1ce096d2f2a53dc3</Hash>
</Codenesium>*/