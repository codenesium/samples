using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>95f23f3267e91cc76af220893071c84e</Hash>
</Codenesium>*/