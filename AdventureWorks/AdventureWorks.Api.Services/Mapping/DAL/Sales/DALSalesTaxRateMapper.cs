using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesTaxRateMapper: DALAbstractSalesTaxRateMapper, IDALSalesTaxRateMapper
        {
                public DALSalesTaxRateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2fac6a143e5de4f99d0dabc27f64fb8c</Hash>
</Codenesium>*/