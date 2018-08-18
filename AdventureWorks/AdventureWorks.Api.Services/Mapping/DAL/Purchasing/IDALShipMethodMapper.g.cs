using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShipMethodMapper
	{
		ShipMethod MapBOToEF(
			BOShipMethod bo);

		BOShipMethod MapEFToBO(
			ShipMethod efShipMethod);

		List<BOShipMethod> MapEFToBO(
			List<ShipMethod> records);
	}
}

/*<Codenesium>
    <Hash>9a65e5c183a9eb42dfa9aa859e21319a</Hash>
</Codenesium>*/