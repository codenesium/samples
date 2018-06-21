using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALCountryRegionCurrencyMapper : DALAbstractCountryRegionCurrencyMapper, IDALCountryRegionCurrencyMapper
        {
                public DALCountryRegionCurrencyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>db1d628b309ab73fb89444508e76cdea</Hash>
</Codenesium>*/