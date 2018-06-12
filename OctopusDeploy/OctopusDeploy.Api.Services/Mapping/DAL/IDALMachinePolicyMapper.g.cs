using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALMachinePolicyMapper
        {
                MachinePolicy MapBOToEF(
                        BOMachinePolicy bo);

                BOMachinePolicy MapEFToBO(
                        MachinePolicy efMachinePolicy);

                List<BOMachinePolicy> MapEFToBO(
                        List<MachinePolicy> records);
        }
}

/*<Codenesium>
    <Hash>7b47975cd70d9615c5b5edb15721a545</Hash>
</Codenesium>*/