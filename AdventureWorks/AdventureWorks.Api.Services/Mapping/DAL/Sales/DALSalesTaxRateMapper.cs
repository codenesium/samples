using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALSalesTaxRateMapper : DALAbstractSalesTaxRateMapper, IDALSalesTaxRateMapper
        {
                public DALSalesTaxRateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2e649024f25c04bba0712afec3319688</Hash>
</Codenesium>*/