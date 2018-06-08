using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCountryRegionMapper: DALAbstractCountryRegionMapper, IDALCountryRegionMapper
        {
                public DALCountryRegionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>4fafc25ddc6a7117dbd4937f45c904fe</Hash>
</Codenesium>*/