using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class BOLAbstractLocationMapper
	{
		public virtual BOLocation MapModelToBO(
			int locationId,
			ApiLocationServerRequestModel model
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

		public virtual ApiLocationServerResponseModel MapBOToModel(
			BOLocation boLocation)
		{
			var model = new ApiLocationServerResponseModel();

			model.SetProperties(boLocation.LocationId, boLocation.GpsLat, boLocation.GpsLong, boLocation.LocationName);

			return model;
		}

		public virtual List<ApiLocationServerResponseModel> MapBOToModel(
			List<BOLocation> items)
		{
			List<ApiLocationServerResponseModel> response = new List<ApiLocationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7c9638a9e8ae28b1c50686e14edfd210</Hash>
</Codenesium>*/