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

                Task<List<WorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<WorkOrderRouting>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>c39b4ad32a4172b24906147bb214f05e</Hash>
</Codenesium>*/