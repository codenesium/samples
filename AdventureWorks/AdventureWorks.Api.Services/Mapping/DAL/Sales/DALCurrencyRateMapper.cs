using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALCurrencyRateMapper : DALAbstractCurrencyRateMapper, IDALCurrencyRateMapper
        {
                public DALCurrencyRateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6f9c034047198189124981ba52dbcbb1</Hash>
</Codenesium>*/