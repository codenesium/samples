using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPurchaseOrderHeaderMapper
        {
                PurchaseOrderHeader MapBOToEF(
                        BOPurchaseOrderHeader bo);

                BOPurchaseOrderHeader MapEFToBO(
                        PurchaseOrderHeader efPurchaseOrderHeader);

                List<BOPurchaseOrderHeader> MapEFToBO(
                        List<PurchaseOrderHeader> records);
        }
}

/*<Codenesium>
    <Hash>1784542c31f2efd1793177342112fc52</Hash>
</Codenesium>*/