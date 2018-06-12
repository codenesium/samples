using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALTenantVariableMapper
        {
                TenantVariable MapBOToEF(
                        BOTenantVariable bo);

                BOTenantVariable MapEFToBO(
                        TenantVariable efTenantVariable);

                List<BOTenantVariable> MapEFToBO(
                        List<TenantVariable> records);
        }
}

/*<Codenesium>
    <Hash>4d8747a88d4ce342371ce254a46f9a42</Hash>
</Codenesium>*/