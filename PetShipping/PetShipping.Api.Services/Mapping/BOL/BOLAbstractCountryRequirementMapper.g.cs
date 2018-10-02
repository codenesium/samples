using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractCountryRequirementMapper
	{
		public virtual BOCountryRequirement MapModelToBO(
			int id,
			ApiCountryRequirementRequestModel model
			)
		{
			BOCountryRequirement boCountryRequirement = new BOCountryRequirement();
			boCountryRequirement.SetProperties(
				id,
				model.CountryId,
				model.Detail);
			return boCountryRequirement;
		}

		public virtual ApiCountryRequirementResponseModel MapBOToModel(
			BOCountryRequirement boCountryRequirement)
		{
			var model = new ApiCountryRequirementResponseModel();

			model.SetProperties(boCountryRequirement.Id, boCountryRequirement.CountryId, boCountryRequirement.Detail);

			return model;
		}

		public virtual List<ApiCountryRequirementResponseModel> MapBOToModel(
			List<BOCountryRequirement> items)
		{
			List<ApiCountryRequirementResponseModel> response = new List<ApiCountryRequirementResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3b3af8d9bbde847d8256dc529f2db271</Hash>
</Codenesium>*/