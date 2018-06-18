using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IWorkOrderRoutingRepository
        {
                Task<WorkOrderRouting> Create(WorkOrderRouting item);

                Task Update(WorkOrderRouting item);

                Task Delete(int workOrderID);

                Task<WorkOrderRouting> Get(int workOrderID);

                Task<List<WorkOrderRouting>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<WorkOrderRouting>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>9b3642fbccdda0856d85ed552c167c6c</Hash>
</Codenesium>*/