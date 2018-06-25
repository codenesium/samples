using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductVendorMapper : DALAbstractProductVendorMapper, IDALProductVendorMapper
        {
                public DALProductVendorMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>793e6f681a6cc56eb0260943e0d6f4b6</Hash>
</Codenesium>*/