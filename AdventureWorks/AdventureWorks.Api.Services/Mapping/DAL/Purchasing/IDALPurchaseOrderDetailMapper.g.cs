using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>1b974229c98e39ccd07f798c905311e1</Hash>
</Codenesium>*/