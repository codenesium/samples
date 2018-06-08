using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesOrderHeaderSalesReasonMapper: DALAbstractSalesOrderHeaderSalesReasonMapper, IDALSalesOrderHeaderSalesReasonMapper
        {
                public DALSalesOrderHeaderSalesReasonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>31f5e011d3988edb537d2c278d789d2c</Hash>
</Codenesium>*/