using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractVenueMapper
	{
		public virtual BOVenue MapModelToBO(
			int id,
			ApiVenueServerRequestModel model
			)
		{
			BOVenue boVenue = new BOVenue();
			boVenue.SetProperties(
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
			return boVenue;
		}

		public virtual ApiVenueServerResponseModel MapBOToModel(
			BOVenue boVenue)
		{
			var model = new ApiVenueServerResponseModel();

			model.SetProperties(boVenue.Id, boVenue.Address1, boVenue.Address2, boVenue.AdminId, boVenue.Email, boVenue.Facebook, boVenue.Name, boVenue.Phone, boVenue.ProvinceId, boVenue.Website);

			return model;
		}

		public virtual List<ApiVenueServerResponseModel> MapBOToModel(
			List<BOVenue> items)
		{
			List<ApiVenueServerResponseModel> response = new List<ApiVenueServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>44c1cc4549cc0e131d9fb72165c5f299</Hash>
</Codenesium>*/