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
				model.Details);
			return boCountryRequirement;
		}

		public virtual ApiCountryRequirementResponseModel MapBOToModel(
			BOCountryRequirement boCountryRequirement)
		{
			var model = new ApiCountryRequirementResponseModel();

			model.SetProperties(boCountryRequirement.Id, boCountryRequirement.CountryId, boCountryRequirement.Details);

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
    <Hash>253aab0564c2d753a1001c4433c56e54</Hash>
</Codenesium>*/