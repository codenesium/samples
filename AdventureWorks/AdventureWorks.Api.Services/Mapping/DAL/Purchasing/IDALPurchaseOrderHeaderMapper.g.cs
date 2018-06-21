using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>83e008ce4740d35bb9c9ee107eb9da3c</Hash>
</Codenesium>*/