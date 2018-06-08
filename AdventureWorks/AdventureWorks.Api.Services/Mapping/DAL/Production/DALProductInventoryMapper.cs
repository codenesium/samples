using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductInventoryMapper: DALAbstractProductInventoryMapper, IDALProductInventoryMapper
        {
                public DALProductInventoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>32ddc28f4ae5df223ed0878faf1460d3</Hash>
</Codenesium>*/