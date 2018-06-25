using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALWorkOrderRoutingMapper : DALAbstractWorkOrderRoutingMapper, IDALWorkOrderRoutingMapper
        {
                public DALWorkOrderRoutingMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>30570a432a7b0afd6175f466e2961014</Hash>
</Codenesium>*/