using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALSalesOrderDetailMapper : DALAbstractSalesOrderDetailMapper, IDALSalesOrderDetailMapper
        {
                public DALSalesOrderDetailMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d94aed1095d60244fd14b01865afaca7</Hash>
</Codenesium>*/