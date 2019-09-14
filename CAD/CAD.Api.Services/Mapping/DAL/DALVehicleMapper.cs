using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALVehicleMapper : IDALVehicleMapper
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
    <Hash>faf59ce8d654a1ed337c07a5841c3f47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/