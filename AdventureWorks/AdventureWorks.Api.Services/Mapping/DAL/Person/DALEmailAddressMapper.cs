using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmailAddressMapper: DALAbstractEmailAddressMapper, IDALEmailAddressMapper
        {
                public DALEmailAddressMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>4bdc1772f34b038b91eded9696ee7f9c</Hash>
</Codenesium>*/