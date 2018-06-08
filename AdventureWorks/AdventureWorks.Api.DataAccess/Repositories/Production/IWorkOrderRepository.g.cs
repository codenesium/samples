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

                Task<List<WorkOrder>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<WorkOrder>> GetProductID(int productID);
                Task<List<WorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID);
        }
}

/*<Codenesium>
    <Hash>b4bdd6f6be3cedbbf6f6fb3601bab277</Hash>
</Codenesium>*/