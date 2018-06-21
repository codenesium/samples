using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALPurchaseOrderHeaderMapper : DALAbstractPurchaseOrderHeaderMapper, IDALPurchaseOrderHeaderMapper
        {
                public DALPurchaseOrderHeaderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b090601e6c6a009c976d715ca2829edf</Hash>
</Codenesium>*/