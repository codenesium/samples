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

                Task<ActionResponse> Update(int id,
                                            ApiMachineRefTeamRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiMachineRefTeamResponseModel> Get(int id);

                Task<List<ApiMachineRefTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5d84226c25e5e5492711e8c5e032aa73</Hash>
</Codenesium>*/