using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>49661af54d10c589ec53e4735c6510c3</Hash>
</Codenesium>*/