using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALShipMethodMapper
	{
		public virtual void MapDTOToEF(
			int shipMethodID,
			DTOShipMethod dto,
			ShipMethod efShipMethod)
		{
			efShipMethod.SetProperties(
				shipMethodID,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid,
				dto.ShipBase,
				dto.ShipRate);
		}

		public virtual DTOShipMethod MapEFToDTO(
			ShipMethod ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOShipMethod();

			dto.SetProperties(
				ef.ShipMethodID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.ShipBase,
				ef.ShipRate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>67adeaf0c64e1518220571dfdadb7dcd</Hash>
</Codenesium>*/