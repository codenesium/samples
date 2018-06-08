using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductSubcategoryMapper: DALAbstractProductSubcategoryMapper, IDALProductSubcategoryMapper
        {
                public DALProductSubcategoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>db6e9c1a024aaba6ca170cb6a6649c1b</Hash>
</Codenesium>*/