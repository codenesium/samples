using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPurchaseOrderHeaderMapper : DALAbstractPurchaseOrderHeaderMapper, IDALPurchaseOrderHeaderMapper
        {
                public DALPurchaseOrderHeaderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d400d986d1cb87f7e9eec0b02df587ac</Hash>
</Codenesium>*/