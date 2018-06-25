using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALCountryRegionCurrencyMapper : DALAbstractCountryRegionCurrencyMapper, IDALCountryRegionCurrencyMapper
        {
                public DALCountryRegionCurrencyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>45ad84e7fefda911c5834255452ed063</Hash>
</Codenesium>*/