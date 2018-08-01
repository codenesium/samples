using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractShipMethodMapper
	{
		public virtual ShipMethod MapBOToEF(
			BOShipMethod bo)
		{
			ShipMethod efShipMethod = new ShipMethod();
			efShipMethod.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.Rowguid,
				bo.ShipBase,
				bo.ShipMethodID,
				bo.ShipRate);
			return efShipMethod;
		}

		public virtual BOShipMethod MapEFToBO(
			ShipMethod ef)
		{
			var bo = new BOShipMethod();

			bo.SetProperties(
				ef.ShipMethodID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.ShipBase,
				ef.ShipRate);
			return bo;
		}

		public virtual List<BOShipMethod> MapEFToBO(
			List<ShipMethod> records)
		{
			List<BOShipMethod> response = new List<BOShipMethod>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bfb9b1df9b9391f59f6d24d4c5c172c5</Hash>
</Codenesium>*/