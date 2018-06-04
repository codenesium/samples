using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShipMethodMapper
	{
		public virtual ShipMethod MapBOToEF(
			BOShipMethod bo)
		{
			ShipMethod efShipMethod = new ShipMethod ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>30948d309bde86bc53be3de77d3caf0e</Hash>
</Codenesium>*/