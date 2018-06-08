using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>97526cebff131811273e8a681f45db94</Hash>
</Codenesium>*/