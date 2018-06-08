using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>3f040b7afaef5521c4a7b161da7db00d</Hash>
</Codenesium>*/