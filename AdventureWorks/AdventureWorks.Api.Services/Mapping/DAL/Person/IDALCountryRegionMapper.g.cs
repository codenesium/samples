using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>8a134cadd0e00a01f5ce93ee04fbac59</Hash>
</Codenesium>*/