using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ad8c874de9820da0bd2a8f30535e2e1d</Hash>
</Codenesium>*/