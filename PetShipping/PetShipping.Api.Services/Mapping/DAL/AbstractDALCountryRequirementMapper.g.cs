using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALCountryRequirementMapper
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
    <Hash>bf3b3c88c3547c9b088e6c015692ce4f</Hash>
</Codenesium>*/