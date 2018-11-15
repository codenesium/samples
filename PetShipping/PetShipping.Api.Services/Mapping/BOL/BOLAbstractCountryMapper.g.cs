using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>a45d5c0c8274859697e25f94f4b6d6c9</Hash>
</Codenesium>*/