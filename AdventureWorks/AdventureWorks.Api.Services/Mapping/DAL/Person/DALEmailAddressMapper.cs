using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmailAddressMapper : DALAbstractEmailAddressMapper, IDALEmailAddressMapper
        {
                public DALEmailAddressMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>870384a8e8b5d8d3e6c7f310fb96c80c</Hash>
</Codenesium>*/