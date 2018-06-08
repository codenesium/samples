using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesOrderDetailMapper: DALAbstractSalesOrderDetailMapper, IDALSalesOrderDetailMapper
        {
                public DALSalesOrderDetailMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>273ab59b886b53de524e3409c0c23417</Hash>
</Codenesium>*/