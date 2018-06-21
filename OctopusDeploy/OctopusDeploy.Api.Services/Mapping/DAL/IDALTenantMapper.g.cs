using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALTenantMapper
        {
                Tenant MapBOToEF(
                        BOTenant bo);

                BOTenant MapEFToBO(
                        Tenant efTenant);

                List<BOTenant> MapEFToBO(
                        List<Tenant> records);
        }
}

/*<Codenesium>
    <Hash>add2b16b7df9202f8dcf1f82b2c108c2</Hash>
</Codenesium>*/