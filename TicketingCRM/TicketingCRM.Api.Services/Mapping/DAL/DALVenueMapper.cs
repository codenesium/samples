using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALVenueMapper : IDALVenueMapper
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
					item.AdminIdNavigation.Id,
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
					item.ProvinceIdNavigation.Id,
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
    <Hash>ae7cbe82c4373cd4565a98890bca06d1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/