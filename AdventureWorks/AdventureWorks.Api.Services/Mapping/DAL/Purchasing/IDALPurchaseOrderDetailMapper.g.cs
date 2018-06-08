using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPurchaseOrderDetailMapper
        {
                PurchaseOrderDetail MapBOToEF(
                        BOPurchaseOrderDetail bo);

                BOPurchaseOrderDetail MapEFToBO(
                        PurchaseOrderDetail efPurchaseOrderDetail);

                List<BOPurchaseOrderDetail> MapEFToBO(
                        List<PurchaseOrderDetail> records);
        }
}

/*<Codenesium>
    <Hash>052108569b9a72a3ad99cd0d1f85b1aa</Hash>
</Codenesium>*/