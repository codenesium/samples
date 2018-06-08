using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>1e111e3149de4935ab11ec5139e6c7a9</Hash>
</Codenesium>*/