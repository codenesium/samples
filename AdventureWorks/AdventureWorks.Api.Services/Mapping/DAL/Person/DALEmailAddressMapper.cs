using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALEmailAddressMapper : DALAbstractEmailAddressMapper, IDALEmailAddressMapper
        {
                public DALEmailAddressMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f20647223808b48b8d728c747f9f0138</Hash>
</Codenesium>*/