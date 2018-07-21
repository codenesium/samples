using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IMachineRefTeamService
        {
                Task<CreateResponse<ApiMachineRefTeamResponseModel>> Create(
                        ApiMachineRefTeamRequestModel model);

                Task<UpdateResponse<ApiMachineRefTeamResponseModel>> Update(int id,
                                                                             ApiMachineRefTeamRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiMachineRefTeamResponseModel> Get(int id);

                Task<List<ApiMachineRefTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8a8f9f3f231dd290998d03222f8c8ff3</Hash>
</Codenesium>*/