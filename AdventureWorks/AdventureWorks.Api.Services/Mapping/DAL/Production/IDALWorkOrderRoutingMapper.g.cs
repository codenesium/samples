using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>db5fb3ff4d6434939b6cc04dcf33842e</Hash>
</Codenesium>*/