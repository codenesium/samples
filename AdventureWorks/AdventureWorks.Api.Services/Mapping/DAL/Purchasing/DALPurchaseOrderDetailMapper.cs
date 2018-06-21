using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALPurchaseOrderDetailMapper : DALAbstractPurchaseOrderDetailMapper, IDALPurchaseOrderDetailMapper
        {
                public DALPurchaseOrderDetailMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>54416ffcc189b8d51ec16f882c176d06</Hash>
</Codenesium>*/