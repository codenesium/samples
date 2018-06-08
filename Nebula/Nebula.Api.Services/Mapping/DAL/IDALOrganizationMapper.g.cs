using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>7f62618ab26576ca77ca35058dbcf81b</Hash>
</Codenesium>*/