using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShipMethodMapper
	{
		public virtual ShipMethod MapModelToEntity(
			int shipMethodID,
			ApiShipMethodServerRequestModel model
			)
		{
			ShipMethod item = new ShipMethod();
			item.SetProperties(
				shipMethodID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.ShipBase,
				model.ShipRate);
			return item;
		}

		public virtual ApiShipMethodServerResponseModel MapEntityToModel(
			ShipMethod item)
		{
			var model = new ApiShipMethodServerResponseModel();

			model.SetProperties(item.ShipMethodID,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid,
			                    item.ShipBase,
			                    item.ShipRate);

			return model;
		}

		public virtual List<ApiShipMethodServerResponseModel> MapEntityToModel(
			List<ShipMethod> items)
		{
			List<ApiShipMethodServerResponseModel> response = new List<ApiShipMethodServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e95dbfb889dfc52b4e9d7c67c7183d46</Hash>
</Codenesium>*/