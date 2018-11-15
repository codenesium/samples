using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractShipMethodMapper
	{
		public virtual BOShipMethod MapModelToBO(
			int shipMethodID,
			ApiShipMethodServerRequestModel model
			)
		{
			BOShipMethod boShipMethod = new BOShipMethod();
			boShipMethod.SetProperties(
				shipMethodID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.ShipBase,
				model.ShipRate);
			return boShipMethod;
		}

		public virtual ApiShipMethodServerResponseModel MapBOToModel(
			BOShipMethod boShipMethod)
		{
			var model = new ApiShipMethodServerResponseModel();

			model.SetProperties(boShipMethod.ShipMethodID, boShipMethod.ModifiedDate, boShipMethod.Name, boShipMethod.Rowguid, boShipMethod.ShipBase, boShipMethod.ShipRate);

			return model;
		}

		public virtual List<ApiShipMethodServerResponseModel> MapBOToModel(
			List<BOShipMethod> items)
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
    <Hash>3f65a003ea43f286018409c5b9f4083c</Hash>
</Codenesium>*/