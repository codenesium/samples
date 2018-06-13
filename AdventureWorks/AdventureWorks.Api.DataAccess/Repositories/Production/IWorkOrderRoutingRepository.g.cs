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

                Task<List<WorkOrderRouting>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<WorkOrderRouting>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>6d377fc8a5687cb3315f66f768521c68</Hash>
</Codenesium>*/