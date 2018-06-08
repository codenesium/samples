using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALWorkOrderMapper
        {
                WorkOrder MapBOToEF(
                        BOWorkOrder bo);

                BOWorkOrder MapEFToBO(
                        WorkOrder efWorkOrder);

                List<BOWorkOrder> MapEFToBO(
                        List<WorkOrder> records);
        }
}

/*<Codenesium>
    <Hash>24401859c84d1a437bdcce607f21b470</Hash>
</Codenesium>*/