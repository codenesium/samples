using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
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
    <Hash>123fefa2304f170bc457510cca771926</Hash>
</Codenesium>*/