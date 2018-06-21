using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesReasonMapper
        {
                SalesReason MapBOToEF(
                        BOSalesReason bo);

                BOSalesReason MapEFToBO(
                        SalesReason efSalesReason);

                List<BOSalesReason> MapEFToBO(
                        List<SalesReason> records);
        }
}

/*<Codenesium>
    <Hash>6762c7bc4bcd22ba03d5896e7c73af13</Hash>
</Codenesium>*/