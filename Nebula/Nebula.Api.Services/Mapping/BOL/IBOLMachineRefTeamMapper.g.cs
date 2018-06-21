using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLMachineRefTeamMapper
        {
                BOMachineRefTeam MapModelToBO(
                        int id,
                        ApiMachineRefTeamRequestModel model);

                ApiMachineRefTeamResponseModel MapBOToModel(
                        BOMachineRefTeam boMachineRefTeam);

                List<ApiMachineRefTeamResponseModel> MapBOToModel(
                        List<BOMachineRefTeam> items);
        }
}

/*<Codenesium>
    <Hash>14c291d55a6850216e86548977b0a21b</Hash>
</Codenesium>*/