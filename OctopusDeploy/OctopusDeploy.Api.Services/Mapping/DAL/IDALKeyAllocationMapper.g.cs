using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALKeyAllocationMapper
        {
                KeyAllocation MapBOToEF(
                        BOKeyAllocation bo);

                BOKeyAllocation MapEFToBO(
                        KeyAllocation efKeyAllocation);

                List<BOKeyAllocation> MapEFToBO(
                        List<KeyAllocation> records);
        }
}

/*<Codenesium>
    <Hash>ca683b7a45fb7bd73e994fd1d81832f0</Hash>
</Codenesium>*/