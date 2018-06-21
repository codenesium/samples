using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALCountryRegionMapper
        {
                CountryRegion MapBOToEF(
                        BOCountryRegion bo);

                BOCountryRegion MapEFToBO(
                        CountryRegion efCountryRegion);

                List<BOCountryRegion> MapEFToBO(
                        List<CountryRegion> records);
        }
}

/*<Codenesium>
    <Hash>22bbeaa29ac571a2d23bfa0f24e639ee</Hash>
</Codenesium>*/