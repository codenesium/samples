using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesTaxRateMapper : DALAbstractSalesTaxRateMapper, IDALSalesTaxRateMapper
        {
                public DALSalesTaxRateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ab57df0631fcec6e5415e622f96389eb</Hash>
</Codenesium>*/