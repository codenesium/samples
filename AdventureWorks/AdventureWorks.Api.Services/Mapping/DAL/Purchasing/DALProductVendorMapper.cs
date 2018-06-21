using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductVendorMapper : DALAbstractProductVendorMapper, IDALProductVendorMapper
        {
                public DALProductVendorMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ad4b531f711ecf964b50df631754621c</Hash>
</Codenesium>*/