using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractShipMethodMapper
	{
		public virtual BOShipMethod MapModelToBO(
			int shipMethodID,
			ApiShipMethodRequestModel model
			)
		{
			BOShipMethod BOShipMethod = new BOShipMethod();

			BOShipMethod.SetProperties(
				shipMethodID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.ShipBase,
				model.ShipRate);
			return BOShipMethod;
		}

		public virtual ApiShipMethodResponseModel MapBOToModel(
			BOShipMethod BOShipMethod)
		{
			if (BOShipMethod == null)
			{
				return null;
			}

			var model = new ApiShipMethodResponseModel();

			model.SetProperties(BOShipMethod.ModifiedDate, BOShipMethod.Name, BOShipMethod.Rowguid, BOShipMethod.ShipBase, BOShipMethod.ShipMethodID, BOShipMethod.ShipRate);

			return model;
		}

		public virtual List<ApiShipMethodResponseModel> MapBOToModel(
			List<BOShipMethod> BOs)
		{
			List<ApiShipMethodResponseModel> response = new List<ApiShipMethodResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>748943585b52a496782587c8990b6741</Hash>
</Codenesium>*/