using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>4e2a11dacc450ce2b8e5ec842165f5ff</Hash>
</Codenesium>*/