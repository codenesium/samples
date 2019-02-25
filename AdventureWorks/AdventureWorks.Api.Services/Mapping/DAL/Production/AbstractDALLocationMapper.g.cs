using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALLocationMapper
	{
		public virtual Location MapModelToEntity(
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

		public virtual ApiLocationServerResponseModel MapEntityToModel(
			Location item)
		{
			var model = new ApiLocationServerResponseModel();

			model.SetProperties(item.LocationID,
			                    item.Availability,
			                    item.CostRate,
			                    item.ModifiedDate,
			                    item.Name);

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
    <Hash>ee7c724076068bd7ad1e286ca1bc20cc</Hash>
</Codenesium>*/