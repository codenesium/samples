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

                Task<List<WorkOrder>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<WorkOrder>> GetProductID(int productID);
                Task<List<WorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID);

                Task<List<WorkOrderRouting>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>59665f8589cc455093b64b0909e296d7</Hash>
</Codenesium>*/