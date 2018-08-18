using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ILocationRepository
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
    <Hash>87ea80b635dbaadf868ae168a28266ae</Hash>
</Codenesium>*/