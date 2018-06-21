using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductInventoryMapper : DALAbstractProductInventoryMapper, IDALProductInventoryMapper
        {
                public DALProductInventoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9c65690f38defdfa755aeb7b3d2c030a</Hash>
</Codenesium>*/