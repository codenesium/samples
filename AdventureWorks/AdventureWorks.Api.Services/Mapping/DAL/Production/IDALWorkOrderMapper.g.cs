using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>e7c76c536263db8d1686550b4359cea1</Hash>
</Codenesium>*/