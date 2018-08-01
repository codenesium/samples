using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALShipMethodMapper
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
    <Hash>7cfc6434f0247f5a2535bb4140958761</Hash>
</Codenesium>*/