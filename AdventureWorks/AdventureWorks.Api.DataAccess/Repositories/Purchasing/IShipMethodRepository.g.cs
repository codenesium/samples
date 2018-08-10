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

		Task<List<ShipMethod>> All(int limit = int.MaxValue, int offset = 0);

		Task<ShipMethod> ByName(string name);

		Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>94c851ab5f0da460de88467ac183f004</Hash>
</Codenesium>*/