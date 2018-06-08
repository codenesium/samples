using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPurchaseOrderDetailMapper: DALAbstractPurchaseOrderDetailMapper, IDALPurchaseOrderDetailMapper
        {
                public DALPurchaseOrderDetailMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e5ccb2ba501b9a8f3520a050e183bff9</Hash>
</Codenesium>*/