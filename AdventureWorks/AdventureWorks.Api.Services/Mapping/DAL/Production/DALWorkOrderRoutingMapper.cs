using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALWorkOrderRoutingMapper: DALAbstractWorkOrderRoutingMapper, IDALWorkOrderRoutingMapper
        {
                public DALWorkOrderRoutingMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9b6e85c3ad866f766e57cd80bec17d1d</Hash>
</Codenesium>*/