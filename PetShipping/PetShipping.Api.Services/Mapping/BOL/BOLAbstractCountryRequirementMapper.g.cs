using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractCountryRequirementMapper
	{
		public virtual BOCountryRequirement MapModelToBO(
			int id,
			ApiCountryRequirementServerRequestModel model
			)
		{
			BOCountryRequirement boCountryRequirement = new BOCountryRequirement();
			boCountryRequirement.SetProperties(
				id,
				model.CountryId,
				model.Detail);
			return boCountryRequirement;
		}

		public virtual ApiCountryRequirementServerResponseModel MapBOToModel(
			BOCountryRequirement boCountryRequirement)
		{
			var model = new ApiCountryRequirementServerResponseModel();

			model.SetProperties(boCountryRequirement.Id, boCountryRequirement.CountryId, boCountryRequirement.Detail);

			return model;
		}

		public virtual List<ApiCountryRequirementServerResponseModel> MapBOToModel(
			List<BOCountryRequirement> items)
		{
			List<ApiCountryRequirementServerResponseModel> response = new List<ApiCountryRequirementServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd3dc1bc36ed8039c5335704a6078be5</Hash>
</Codenesium>*/