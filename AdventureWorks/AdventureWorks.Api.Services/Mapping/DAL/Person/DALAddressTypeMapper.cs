using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALAddressTypeMapper: DALAbstractAddressTypeMapper, IDALAddressTypeMapper
        {
                public DALAddressTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>84703b1ac17cac4034eb89d73a875bf3</Hash>
</Codenesium>*/