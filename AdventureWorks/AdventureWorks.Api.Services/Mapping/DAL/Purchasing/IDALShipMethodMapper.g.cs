using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>dd40087eec54174f12abb14a663800c8</Hash>
</Codenesium>*/