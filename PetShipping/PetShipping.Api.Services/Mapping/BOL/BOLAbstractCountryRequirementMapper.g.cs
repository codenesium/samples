using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
				model.Details);
			return boCountryRequirement;
		}

		public virtual ApiCountryRequirementResponseModel MapBOToModel(
			BOCountryRequirement boCountryRequirement)
		{
			var model = new ApiCountryRequirementResponseModel();

			model.SetProperties(boCountryRequirement.CountryId, boCountryRequirement.Details, boCountryRequirement.Id);

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
    <Hash>8a6c27355a0e5829c7561f5db27ba706</Hash>
</Codenesium>*/