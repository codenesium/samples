using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductCategoryMapper : DALAbstractProductCategoryMapper, IDALProductCategoryMapper
        {
                public DALProductCategoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9c64b9cb1eedec5ab6dc86fd8b44c0dd</Hash>
</Codenesium>*/