using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPurchaseOrderDetailMapper : DALAbstractPurchaseOrderDetailMapper, IDALPurchaseOrderDetailMapper
        {
                public DALPurchaseOrderDetailMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>73d5d30a97fe5786065a92bf132c58a0</Hash>
</Codenesium>*/