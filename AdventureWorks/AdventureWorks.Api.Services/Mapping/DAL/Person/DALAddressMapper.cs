using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALAddressMapper : DALAbstractAddressMapper, IDALAddressMapper
        {
                public DALAddressMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b0de429f5a28fbebfea437e52486921a</Hash>
</Codenesium>*/