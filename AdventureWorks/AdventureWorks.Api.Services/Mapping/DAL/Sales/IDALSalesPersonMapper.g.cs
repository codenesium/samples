using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesPersonMapper
        {
                SalesPerson MapBOToEF(
                        BOSalesPerson bo);

                BOSalesPerson MapEFToBO(
                        SalesPerson efSalesPerson);

                List<BOSalesPerson> MapEFToBO(
                        List<SalesPerson> records);
        }
}

/*<Codenesium>
    <Hash>67f17fcdfd2595da837c7916079e15cd</Hash>
</Codenesium>*/