using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductModelMapper : DALAbstractProductModelMapper, IDALProductModelMapper
        {
                public DALProductModelMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6b465983067571d0eb704fe874366fc7</Hash>
</Codenesium>*/