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

		Task<List<Location>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Location> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>55f540979d57db150b6ef0e479da7c54</Hash>
</Codenesium>*/