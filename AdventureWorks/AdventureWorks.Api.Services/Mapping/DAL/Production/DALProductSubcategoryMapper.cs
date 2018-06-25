using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductSubcategoryMapper : DALAbstractProductSubcategoryMapper, IDALProductSubcategoryMapper
        {
                public DALProductSubcategoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b5104d7da704446e0b339f6649654389</Hash>
</Codenesium>*/