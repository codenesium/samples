using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>35f1576cb82d493005615b583a8e93c7</Hash>
</Codenesium>*/