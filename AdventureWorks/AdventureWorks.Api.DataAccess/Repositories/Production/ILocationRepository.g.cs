using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ILocationRepository
        {
                Task<Location> Create(Location item);

                Task Update(Location item);

                Task Delete(short locationID);

                Task<Location> Get(short locationID);

                Task<List<Location>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Location> GetName(string name);

                Task<List<ProductInventory>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0);
                Task<List<WorkOrderRouting>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>628ffa65cc7bbd9a68c62c84d554b5d3</Hash>
</Codenesium>*/