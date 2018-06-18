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

                Task<List<Location>> All(int limit = int.MaxValue, int offset = 0);

                Task<Location> ByName(string name);

                Task<List<ProductInventory>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0);
                Task<List<WorkOrderRouting>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>baa689a00f17bcd70120fc438677961b</Hash>
</Codenesium>*/