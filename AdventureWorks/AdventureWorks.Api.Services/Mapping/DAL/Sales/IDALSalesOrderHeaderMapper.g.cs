using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>1fdbf8ab794bdaddb6d6740bd0336e4c</Hash>
</Codenesium>*/