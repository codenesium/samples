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
	}
}

/*<Codenesium>
    <Hash>3a31564c95b4b68488a957d10e5fa822</Hash>
</Codenesium>*/