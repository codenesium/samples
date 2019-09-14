using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class DALLocationMapper : IDALLocationMapper
	{
		public virtual Location MapModelToEntity(
			int locationId,
			ApiLocationServerRequestModel model
			)
		{
			Location item = new Location();
			item.SetProperties(
				locationId,
				model.GpsLat,
				model.GpsLong,
				model.LocationName);
			return item;
		}

		public virtual ApiLocationServerResponseModel MapEntityToModel(
			Location item)
		{
			var model = new ApiLocationServerResponseModel();

			model.SetProperties(item.LocationId,
			                    item.GpsLat,
			                    item.GpsLong,
			                    item.LocationName);

			return model;
		}

		public virtual List<ApiLocationServerResponseModel> MapEntityToModel(
			List<Location> items)
		{
			List<ApiLocationServerResponseModel> response = new List<ApiLocationServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a502816f9e90b51d0362e2aac97cd82d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/