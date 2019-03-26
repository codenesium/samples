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

		Task<List<Location>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Location> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>fb1d8f6528a5cb8653467424c0f18f21</Hash>
</Codenesium>*/