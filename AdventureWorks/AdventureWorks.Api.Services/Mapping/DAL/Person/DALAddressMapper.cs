using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALAddressMapper: DALAbstractAddressMapper, IDALAddressMapper
        {
                public DALAddressMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7e5b55ba87e07dc801c02183f8f63738</Hash>
</Codenesium>*/