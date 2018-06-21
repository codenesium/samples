using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>4dc71f66ba3ed06f2bb51852b6fba6a3</Hash>
</Codenesium>*/