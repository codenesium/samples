using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALLocationMapper
	{
		public virtual Location MapModelToBO(
			short locationID,
			ApiLocationServerRequestModel model
			)
		{
			Location item = new Location();
			item.SetProperties(
				locationID,
				model.Availability,
				model.CostRate,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiLocationServerResponseModel MapBOToModel(
			Location item)
		{
			var model = new ApiLocationServerResponseModel();

			model.SetProperties(item.LocationID, item.Availability, item.CostRate, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiLocationServerResponseModel> MapBOToModel(
			List<Location> items)
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
    <Hash>6587d6ef083db8dc31c6f5a2790e7aa0</Hash>
</Codenesium>*/