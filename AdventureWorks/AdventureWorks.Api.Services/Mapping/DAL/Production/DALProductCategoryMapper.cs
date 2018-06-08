using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductCategoryMapper: DALAbstractProductCategoryMapper, IDALProductCategoryMapper
        {
                public DALProductCategoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>84c77bd3a811e2b35df9f56a4255b35e</Hash>
</Codenesium>*/