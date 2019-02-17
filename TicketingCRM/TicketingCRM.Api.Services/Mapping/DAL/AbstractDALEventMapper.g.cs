using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALEventMapper
	{
		public virtual Event MapModelToEntity(
			int id,
			ApiEventServerRequestModel model
			)
		{
			Event item = new Event();
			item.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.CityId,
				model.Date,
				model.Description,
				model.EndDate,
				model.Facebook,
				model.Name,
				model.StartDate,
				model.Website);
			return item;
		}

		public virtual ApiEventServerResponseModel MapEntityToModel(
			Event item)
		{
			var model = new ApiEventServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Address1,
			                    item.Address2,
			                    item.CityId,
			                    item.Date,
			                    item.Description,
			                    item.EndDate,
			                    item.Facebook,
			                    item.Name,
			                    item.StartDate,
			                    item.Website);
			if (item.CityIdNavigation != null)
			{
				var cityIdModel = new ApiCityServerResponseModel();
				cityIdModel.SetProperties(
					item.CityIdNavigation.Id,
					item.CityIdNavigation.Name,
					item.CityIdNavigation.ProvinceId);

				model.SetCityIdNavigation(cityIdModel);
			}

			return model;
		}

		public virtual List<ApiEventServerResponseModel> MapEntityToModel(
			List<Event> items)
		{
			List<ApiEventServerResponseModel> response = new List<ApiEventServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e9fab3fabbeef25a5d29883fc57d9a84</Hash>
</Codenesium>*/