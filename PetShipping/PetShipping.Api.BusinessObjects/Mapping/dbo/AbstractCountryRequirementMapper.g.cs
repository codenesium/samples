using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCountryRequirementMapper
	{
		public virtual DTOCountryRequirement MapModelToDTO(
			int id,
			ApiCountryRequirementRequestModel model
			)
		{
			DTOCountryRequirement dtoCountryRequirement = new DTOCountryRequirement();

			dtoCountryRequirement.SetProperties(
				id,
				model.CountryId,
				model.Details);
			return dtoCountryRequirement;
		}

		public virtual ApiCountryRequirementResponseModel MapDTOToModel(
			DTOCountryRequirement dtoCountryRequirement)
		{
			if (dtoCountryRequirement == null)
			{
				return null;
			}

			var model = new ApiCountryRequirementResponseModel();

			model.SetProperties(dtoCountryRequirement.CountryId, dtoCountryRequirement.Details, dtoCountryRequirement.Id);

			return model;
		}

		public virtual List<ApiCountryRequirementResponseModel> MapDTOToModel(
			List<DTOCountryRequirement> dtos)
		{
			List<ApiCountryRequirementResponseModel> response = new List<ApiCountryRequirementResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4b786cc96cc2da001326cf67b9de34fe</Hash>
</Codenesium>*/