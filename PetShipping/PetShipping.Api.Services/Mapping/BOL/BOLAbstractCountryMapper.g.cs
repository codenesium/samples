using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractCountryMapper
	{
		public virtual BOCountry MapModelToBO(
			int id,
			ApiCountryRequestModel model
			)
		{
			BOCountry boCountry = new BOCountry();

			boCountry.SetProperties(
				id,
				model.Name);
			return boCountry;
		}

		public virtual ApiCountryResponseModel MapBOToModel(
			BOCountry boCountry)
		{
			var model = new ApiCountryResponseModel();

			model.SetProperties(boCountry.Id, boCountry.Name);

			return model;
		}

		public virtual List<ApiCountryResponseModel> MapBOToModel(
			List<BOCountry> items)
		{
			List<ApiCountryResponseModel> response = new List<ApiCountryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>593b06ff520beb5686df672ad300bd01</Hash>
</Codenesium>*/