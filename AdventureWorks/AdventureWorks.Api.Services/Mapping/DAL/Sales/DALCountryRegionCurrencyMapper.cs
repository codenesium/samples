using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCountryRegionCurrencyMapper: DALAbstractCountryRegionCurrencyMapper, IDALCountryRegionCurrencyMapper
        {
                public DALCountryRegionCurrencyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f6533da85b6593c06b5329d6c4774ecd</Hash>
</Codenesium>*/