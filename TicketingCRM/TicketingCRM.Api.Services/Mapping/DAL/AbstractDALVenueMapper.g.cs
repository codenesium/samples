using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALVenueMapper
	{
		public virtual Venue MapModelToEntity(
			int id,
			ApiVenueServerRequestModel model
			)
		{
			Venue item = new Venue();
			item.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.AdminId,
				model.Email,
				model.Facebook,
				model.Name,
				model.Phone,
				model.ProvinceId,
				model.Website);
			return item;
		}

		public virtual ApiVenueServerResponseModel MapEntityToModel(
			Venue item)
		{
			var model = new ApiVenueServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Address1,
			                    item.Address2,
			                    item.AdminId,
			                    item.Email,
			                    item.Facebook,
			                    item.Name,
			                    item.Phone,
			                    item.ProvinceId,
			                    item.Website);
			if (item.AdminIdNavigation != null)
			{
				var adminIdModel = new ApiAdminServerResponseModel();
				adminIdModel.SetProperties(
					item.Id,
					item.AdminIdNavigation.Email,
					item.AdminIdNavigation.FirstName,
					item.AdminIdNavigation.LastName,
					item.AdminIdNavigation.Password,
					item.AdminIdNavigation.Phone,
					item.AdminIdNavigation.Username);

				model.SetAdminIdNavigation(adminIdModel);
			}

			if (item.ProvinceIdNavigation != null)
			{
				var provinceIdModel = new ApiProvinceServerResponseModel();
				provinceIdModel.SetProperties(
					item.Id,
					item.ProvinceIdNavigation.CountryId,
					item.ProvinceIdNavigation.Name);

				model.SetProvinceIdNavigation(provinceIdModel);
			}

			return model;
		}

		public virtual List<ApiVenueServerResponseModel> MapEntityToModel(
			List<Venue> items)
		{
			List<ApiVenueServerResponseModel> response = new List<ApiVenueServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>251dbaa708aba9195670833d315970d8</Hash>
</Codenesium>*/