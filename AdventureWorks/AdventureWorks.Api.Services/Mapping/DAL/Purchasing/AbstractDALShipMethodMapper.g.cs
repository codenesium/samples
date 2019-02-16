using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShipMethodMapper
	{
		public virtual ShipMethod MapModelToBO(
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

		public virtual ApiShipMethodServerResponseModel MapBOToModel(
			ShipMethod item)
		{
			var model = new ApiShipMethodServerResponseModel();

			model.SetProperties(item.ShipMethodID, item.ModifiedDate, item.Name, item.Rowguid, item.ShipBase, item.ShipRate);

			return model;
		}

		public virtual List<ApiShipMethodServerResponseModel> MapBOToModel(
			List<ShipMethod> items)
		{
			List<ApiShipMethodServerResponseModel> response = new List<ApiShipMethodServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>62a8d3d6a0984af945c78b13293c5946</Hash>
</Codenesium>*/