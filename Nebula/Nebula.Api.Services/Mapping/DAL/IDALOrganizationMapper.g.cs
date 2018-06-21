using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IDALOrganizationMapper
        {
                Organization MapBOToEF(
                        BOOrganization bo);

                BOOrganization MapEFToBO(
                        Organization efOrganization);

                List<BOOrganization> MapEFToBO(
                        List<Organization> records);
        }
}

/*<Codenesium>
    <Hash>1d7f19448e7637526d746887f7dfca31</Hash>
</Codenesium>*/