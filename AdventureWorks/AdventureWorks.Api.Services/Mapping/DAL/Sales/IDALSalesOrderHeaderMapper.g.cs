using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesOrderHeaderMapper
        {
                SalesOrderHeader MapBOToEF(
                        BOSalesOrderHeader bo);

                BOSalesOrderHeader MapEFToBO(
                        SalesOrderHeader efSalesOrderHeader);

                List<BOSalesOrderHeader> MapEFToBO(
                        List<SalesOrderHeader> records);
        }
}

/*<Codenesium>
    <Hash>73926c861a6f2711caf8651e3fd61b8d</Hash>
</Codenesium>*/