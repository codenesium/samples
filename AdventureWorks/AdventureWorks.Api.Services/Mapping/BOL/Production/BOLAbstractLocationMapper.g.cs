using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractLocationMapper
	{
		public virtual BOLocation MapModelToBO(
			short locationID,
			ApiLocationRequestModel model
			)
		{
			BOLocation BOLocation = new BOLocation();

			BOLocation.SetProperties(
				locationID,
				model.Availability,
				model.CostRate,
				model.ModifiedDate,
				model.Name);
			return BOLocation;
		}

		public virtual ApiLocationResponseModel MapBOToModel(
			BOLocation BOLocation)
		{
			if (BOLocation == null)
			{
				return null;
			}

			var model = new ApiLocationResponseModel();

			model.SetProperties(BOLocation.Availability, BOLocation.CostRate, BOLocation.LocationID, BOLocation.ModifiedDate, BOLocation.Name);

			return model;
		}

		public virtual List<ApiLocationResponseModel> MapBOToModel(
			List<BOLocation> BOs)
		{
			List<ApiLocationResponseModel> response = new List<ApiLocationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96692aef8612ede8a2d793e0f8446949</Hash>
</Codenesium>*/