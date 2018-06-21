using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IDALMachineMapper
        {
                Machine MapBOToEF(
                        BOMachine bo);

                BOMachine MapEFToBO(
                        Machine efMachine);

                List<BOMachine> MapEFToBO(
                        List<Machine> records);
        }
}

/*<Codenesium>
    <Hash>c87015dae6a6ad0525587ccf1056ef05</Hash>
</Codenesium>*/