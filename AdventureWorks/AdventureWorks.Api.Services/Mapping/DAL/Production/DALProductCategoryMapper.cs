using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductCategoryMapper : DALAbstractProductCategoryMapper, IDALProductCategoryMapper
        {
                public DALProductCategoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>bc38ed353f35c75d813edf689491a680</Hash>
</Codenesium>*/