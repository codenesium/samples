using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesOrderDetailMapper
        {
                SalesOrderDetail MapBOToEF(
                        BOSalesOrderDetail bo);

                BOSalesOrderDetail MapEFToBO(
                        SalesOrderDetail efSalesOrderDetail);

                List<BOSalesOrderDetail> MapEFToBO(
                        List<SalesOrderDetail> records);
        }
}

/*<Codenesium>
    <Hash>53de7f939d5d986566ac74a6af6d0203</Hash>
</Codenesium>*/