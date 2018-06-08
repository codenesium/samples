using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>ca5b564390176d069376a9a69a0e00b4</Hash>
</Codenesium>*/