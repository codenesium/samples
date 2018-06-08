using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesTerritoryMapper: DALAbstractSalesTerritoryMapper, IDALSalesTerritoryMapper
        {
                public DALSalesTerritoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9bcab67ecdbc7f2f3323d6cb8195b6ef</Hash>
</Codenesium>*/