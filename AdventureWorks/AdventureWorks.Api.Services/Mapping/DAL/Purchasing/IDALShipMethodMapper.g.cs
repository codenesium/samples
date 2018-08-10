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
    <Hash>cd9e7176e47f808f4c6ecc03d3658122</Hash>
</Codenesium>*/