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
				model.Detail);
			return item;
		}

		public virtual ApiCountryRequirementServerResponseModel MapEntityToModel(
			CountryRequirement item)
		{
			var model = new ApiCountryRequirementServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CountryId,
			                    item.Detail);
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
    <Hash>e00c565125b728c5688cdf243e96c6d9</Hash>
</Codenesium>*/