using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALCountryRequirementMapper : IDALCountryRequirementMapper
	{
		public virtual CountryRequirement MapModelToEntity(
			int id,
			ApiCountryRequirementServerRequestModel model
			)
		{
			CountryRequirement item = new CountryRequirement();
			item.SetProperties(
				id,
				model.CountryId,
				model.Details);
			return item;
		}

		public virtual ApiCountryRequirementServerResponseModel MapEntityToModel(
			CountryRequirement item)
		{
			var model = new ApiCountryRequirementServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CountryId,
			                    item.Details);
			if (item.CountryIdNavigation != null)
			{
				var countryIdModel = new ApiCountryServerResponseModel();
				countryIdModel.SetProperties(
					item.CountryIdNavigation.Id,
					item.CountryIdNavigation.Name);

				model.SetCountryIdNavigation(countryIdModel);
			}

			return model;
		}

		public virtual List<ApiCountryRequirementServerResponseModel> MapEntityToModel(
			List<CountryRequirement> items)
		{
			List<ApiCountryRequirementServerResponseModel> response = new List<ApiCountryRequirementServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>76e0c3221f2c9e5274de9b0b6a9110b7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/