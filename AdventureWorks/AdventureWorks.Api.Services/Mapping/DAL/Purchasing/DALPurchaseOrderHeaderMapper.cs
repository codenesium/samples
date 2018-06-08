using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPurchaseOrderHeaderMapper: DALAbstractPurchaseOrderHeaderMapper, IDALPurchaseOrderHeaderMapper
        {
                public DALPurchaseOrderHeaderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7bb2856837f9220b9b629fb5d5c96be2</Hash>
</Codenesium>*/