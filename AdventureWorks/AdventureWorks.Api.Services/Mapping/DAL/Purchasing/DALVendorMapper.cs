using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALVendorMapper : DALAbstractVendorMapper, IDALVendorMapper
        {
                public DALVendorMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>de8358946c99bb1848ad1385b550e338</Hash>
</Codenesium>*/