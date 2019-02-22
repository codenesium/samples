using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleMapper
	{
		public virtual Vehicle MapModelToEntity(
			int id,
			ApiVehicleServerRequestModel model
			)
		{
			Vehicle item = new Vehicle();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiVehicleServerResponseModel MapEntityToModel(
			Vehicle item)
		{
			var model = new ApiVehicleServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiVehicleServerResponseModel> MapEntityToModel(
			List<Vehicle> items)
		{
			List<ApiVehicleServerResponseModel> response = new List<ApiVehicleServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1f189b9fd3f125246cf36239116cba9c</Hash>
</Codenesium>*/