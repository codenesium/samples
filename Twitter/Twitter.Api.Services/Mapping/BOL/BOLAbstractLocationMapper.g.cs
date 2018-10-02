using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractLocationMapper
	{
		public virtual BOLocation MapModelToBO(
			int locationId,
			ApiLocationRequestModel model
			)
		{
			BOLocation boLocation = new BOLocation();
			boLocation.SetProperties(
				locationId,
				model.GpsLat,
				model.GpsLong,
				model.LocationName);
			return boLocation;
		}

		public virtual ApiLocationResponseModel MapBOToModel(
			BOLocation boLocation)
		{
			var model = new ApiLocationResponseModel();

			model.SetProperties(boLocation.LocationId, boLocation.GpsLat, boLocation.GpsLong, boLocation.LocationName);

			return model;
		}

		public virtual List<ApiLocationResponseModel> MapBOToModel(
			List<BOLocation> items)
		{
			List<ApiLocationResponseModel> response = new List<ApiLocationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8e93cf755acf32f7024f5fd5ccdd8e6e</Hash>
</Codenesium>*/