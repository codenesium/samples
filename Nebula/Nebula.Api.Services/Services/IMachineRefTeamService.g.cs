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

                Task<List<ApiMachineRefTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2355e8b765b3d47ea7cf2010a859ea0d</Hash>
</Codenesium>*/