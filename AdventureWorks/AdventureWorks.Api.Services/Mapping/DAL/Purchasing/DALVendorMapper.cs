using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALVendorMapper: DALAbstractVendorMapper, IDALVendorMapper
        {
                public DALVendorMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>fffcdbeb337efc5ed55fd3345324a697</Hash>
</Codenesium>*/