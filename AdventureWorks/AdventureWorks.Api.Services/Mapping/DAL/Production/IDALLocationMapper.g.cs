using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALLocationMapper
        {
                Location MapBOToEF(
                        BOLocation bo);

                BOLocation MapEFToBO(
                        Location efLocation);

                List<BOLocation> MapEFToBO(
                        List<Location> records);
        }
}

/*<Codenesium>
    <Hash>682e65a14970aa51e7251d6dcfcfa990</Hash>
</Codenesium>*/