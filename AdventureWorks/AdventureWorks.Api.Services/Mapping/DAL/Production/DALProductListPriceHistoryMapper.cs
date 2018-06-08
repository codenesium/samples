using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductListPriceHistoryMapper: DALAbstractProductListPriceHistoryMapper, IDALProductListPriceHistoryMapper
        {
                public DALProductListPriceHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b263e4e168f02d41276b662f0e9d13cc</Hash>
</Codenesium>*/