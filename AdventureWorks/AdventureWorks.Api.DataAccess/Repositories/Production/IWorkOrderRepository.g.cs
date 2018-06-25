using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IWorkOrderRepository
        {
                Task<WorkOrder> Create(WorkOrder item);

                Task Update(WorkOrder item);

                Task Delete(int workOrderID);

                Task<WorkOrder> Get(int workOrderID);

                Task<List<WorkOrder>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<WorkOrder>> ByProductID(int productID);

                Task<List<WorkOrder>> ByScrapReasonID(short? scrapReasonID);

                Task<List<WorkOrderRouting>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f8fd197a78e0c19b90ceb8640e337032</Hash>
</Codenesium>*/