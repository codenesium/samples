using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALShipMethodMapper
	{
		void MapDTOToEF(
			int shipMethodID,
			DTOShipMethod dto,
			ShipMethod efShipMethod);

		DTOShipMethod MapEFToDTO(
			ShipMethod efShipMethod);
	}
}

/*<Codenesium>
    <Hash>677b429ff88b9603b64611d2c109066b</Hash>
</Codenesium>*/