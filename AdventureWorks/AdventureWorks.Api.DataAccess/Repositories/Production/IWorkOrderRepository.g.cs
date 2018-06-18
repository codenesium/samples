using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
                Task<List<WorkOrder>> ByScrapReasonID(Nullable<short> scrapReasonID);

                Task<List<WorkOrderRouting>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5fe3785768713bde1f983cfece4c3c91</Hash>
</Codenesium>*/