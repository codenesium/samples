using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>72397c7c7f28409348893f74b16255df</Hash>
</Codenesium>*/