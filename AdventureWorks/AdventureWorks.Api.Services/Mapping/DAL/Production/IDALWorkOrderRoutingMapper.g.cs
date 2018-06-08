using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALWorkOrderRoutingMapper
        {
                WorkOrderRouting MapBOToEF(
                        BOWorkOrderRouting bo);

                BOWorkOrderRouting MapEFToBO(
                        WorkOrderRouting efWorkOrderRouting);

                List<BOWorkOrderRouting> MapEFToBO(
                        List<WorkOrderRouting> records);
        }
}

/*<Codenesium>
    <Hash>d9555beb1423fe681be659481c418638</Hash>
</Codenesium>*/