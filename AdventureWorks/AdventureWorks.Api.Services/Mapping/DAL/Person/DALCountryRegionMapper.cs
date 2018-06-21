using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALCountryRegionMapper : DALAbstractCountryRegionMapper, IDALCountryRegionMapper
        {
                public DALCountryRegionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f5cabb1699fca38d36c94f40ddc5fc78</Hash>
</Codenesium>*/