using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductInventoryMapper : DALAbstractProductInventoryMapper, IDALProductInventoryMapper
        {
                public DALProductInventoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c80d0682240d47743cdab222fa67a1e5</Hash>
</Codenesium>*/