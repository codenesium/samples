using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>e17ef29fb6512941744c0c6f3209d0f9</Hash>
</Codenesium>*/