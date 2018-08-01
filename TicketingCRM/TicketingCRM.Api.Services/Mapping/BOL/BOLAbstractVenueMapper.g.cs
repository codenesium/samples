using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractVenueMapper
	{
		public virtual BOVenue MapModelToBO(
			int id,
			ApiVenueRequestModel model
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

		public virtual ApiVenueResponseModel MapBOToModel(
			BOVenue boVenue)
		{
			var model = new ApiVenueResponseModel();

			model.SetProperties(boVenue.Id, boVenue.Address1, boVenue.Address2, boVenue.AdminId, boVenue.Email, boVenue.Facebook, boVenue.Name, boVenue.Phone, boVenue.ProvinceId, boVenue.Website);

			return model;
		}

		public virtual List<ApiVenueResponseModel> MapBOToModel(
			List<BOVenue> items)
		{
			List<ApiVenueResponseModel> response = new List<ApiVenueResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e065461484f6b157e3c098636c0cfff2</Hash>
</Codenesium>*/