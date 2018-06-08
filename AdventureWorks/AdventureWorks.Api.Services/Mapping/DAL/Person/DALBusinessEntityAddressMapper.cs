using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALBusinessEntityAddressMapper: DALAbstractBusinessEntityAddressMapper, IDALBusinessEntityAddressMapper
        {
                public DALBusinessEntityAddressMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f6791af531e26c89376192427b6f8179</Hash>
</Codenesium>*/