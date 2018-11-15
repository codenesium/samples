using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractLocationMapper
	{
		public virtual BOLocation MapModelToBO(
			short locationID,
			ApiLocationServerRequestModel model
			)
		{
			BOLocation boLocation = new BOLocation();
			boLocation.SetProperties(
				locationID,
				model.Availability,
				model.CostRate,
				model.ModifiedDate,
				model.Name);
			return boLocation;
		}

		public virtual ApiLocationServerResponseModel MapBOToModel(
			BOLocation boLocation)
		{
			var model = new ApiLocationServerResponseModel();

			model.SetProperties(boLocation.LocationID, boLocation.Availability, boLocation.CostRate, boLocation.ModifiedDate, boLocation.Name);

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
    <Hash>c14faf3fc00e246a3b5dda187cbb8577</Hash>
</Codenesium>*/