using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesOrderHeaderSalesReasonMapper
        {
                SalesOrderHeaderSalesReason MapBOToEF(
                        BOSalesOrderHeaderSalesReason bo);

                BOSalesOrderHeaderSalesReason MapEFToBO(
                        SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason);

                List<BOSalesOrderHeaderSalesReason> MapEFToBO(
                        List<SalesOrderHeaderSalesReason> records);
        }
}

/*<Codenesium>
    <Hash>a37a68b5f5cfbd2842e712e3a9285e1e</Hash>
</Codenesium>*/