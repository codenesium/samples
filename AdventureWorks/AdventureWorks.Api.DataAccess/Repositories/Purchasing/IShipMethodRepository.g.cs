using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		Task<ShipMethod> Create(ShipMethod item);

		Task Update(ShipMethod item);

		Task Delete(int shipMethodID);

		Task<ShipMethod> Get(int shipMethodID);

		Task<List<ShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ShipMethod> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>8b2eaba8ae7eb7ed447bcb276e764210</Hash>
</Codenesium>*/