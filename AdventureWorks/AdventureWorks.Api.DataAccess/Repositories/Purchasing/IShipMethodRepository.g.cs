using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IShipMethodRepository
	{
		Task<ShipMethod> Create(ShipMethod item);

		Task Update(ShipMethod item);

		Task Delete(int shipMethodID);

		Task<ShipMethod> Get(int shipMethodID);

		Task<List<ShipMethod>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ShipMethod> ByName(string name);

		Task<ShipMethod> ByRowguid(Guid rowguid);

		Task<List<PurchaseOrderHeader>> PurchaseOrderHeadersByShipMethodID(int shipMethodID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>944279008cc12e1cd1971574550f65ca</Hash>
</Codenesium>*/