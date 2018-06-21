using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALWorkOrderRoutingMapper : DALAbstractWorkOrderRoutingMapper, IDALWorkOrderRoutingMapper
        {
                public DALWorkOrderRoutingMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b2938dee7086103a0c4e87028b907bfe</Hash>
</Codenesium>*/