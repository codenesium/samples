using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>36ae939abd80905de9475ca36b621565</Hash>
</Codenesium>*/