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
			BOCountry BOCountry = new BOCountry();

			BOCountry.SetProperties(
				id,
				model.Name);
			return BOCountry;
		}

		public virtual ApiCountryResponseModel MapBOToModel(
			BOCountry BOCountry)
		{
			if (BOCountry == null)
			{
				return null;
			}

			var model = new ApiCountryResponseModel();

			model.SetProperties(BOCountry.Id, BOCountry.Name);

			return model;
		}

		public virtual List<ApiCountryResponseModel> MapBOToModel(
			List<BOCountry> BOs)
		{
			List<ApiCountryResponseModel> response = new List<ApiCountryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a73b451f403c26a88b08fe170d533c38</Hash>
</Codenesium>*/