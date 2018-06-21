using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IDALMachineRefTeamMapper
        {
                MachineRefTeam MapBOToEF(
                        BOMachineRefTeam bo);

                BOMachineRefTeam MapEFToBO(
                        MachineRefTeam efMachineRefTeam);

                List<BOMachineRefTeam> MapEFToBO(
                        List<MachineRefTeam> records);
        }
}

/*<Codenesium>
    <Hash>2bb170f747c61fabfa240f1816879adf</Hash>
</Codenesium>*/