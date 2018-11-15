using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractCountryMapper
	{
		public virtual BOCountry MapModelToBO(
			int id,
			ApiCountryServerRequestModel model
			)
		{
			BOCountry boCountry = new BOCountry();
			boCountry.SetProperties(
				id,
				model.Name);
			return boCountry;
		}

		public virtual ApiCountryServerResponseModel MapBOToModel(
			BOCountry boCountry)
		{
			var model = new ApiCountryServerResponseModel();

			model.SetProperties(boCountry.Id, boCountry.Name);

			return model;
		}

		public virtual List<ApiCountryServerResponseModel> MapBOToModel(
			List<BOCountry> items)
		{
			List<ApiCountryServerResponseModel> response = new List<ApiCountryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>58ba2f47356f619cadd541d491065112</Hash>
</Codenesium>*/