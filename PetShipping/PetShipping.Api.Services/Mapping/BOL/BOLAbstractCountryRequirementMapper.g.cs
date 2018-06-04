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
			BOCountryRequirement BOCountryRequirement = new BOCountryRequirement();

			BOCountryRequirement.SetProperties(
				id,
				model.CountryId,
				model.Details);
			return BOCountryRequirement;
		}

		public virtual ApiCountryRequirementResponseModel MapBOToModel(
			BOCountryRequirement BOCountryRequirement)
		{
			if (BOCountryRequirement == null)
			{
				return null;
			}

			var model = new ApiCountryRequirementResponseModel();

			model.SetProperties(BOCountryRequirement.CountryId, BOCountryRequirement.Details, BOCountryRequirement.Id);

			return model;
		}

		public virtual List<ApiCountryRequirementResponseModel> MapBOToModel(
			List<BOCountryRequirement> BOs)
		{
			List<ApiCountryRequirementResponseModel> response = new List<ApiCountryRequirementResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a7b32b8fb3715796b162068876ae708b</Hash>
</Codenesium>*/