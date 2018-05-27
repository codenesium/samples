using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLBreedMapper
	{
		public virtual DTOBreed MapModelToDTO(
			int id,
			ApiBreedRequestModel model
			)
		{
			DTOBreed dtoBreed = new DTOBreed();

			dtoBreed.SetProperties(
				id,
				model.Name,
				model.SpeciesId);
			return dtoBreed;
		}

		public virtual ApiBreedResponseModel MapDTOToModel(
			DTOBreed dtoBreed)
		{
			if (dtoBreed == null)
			{
				return null;
			}

			var model = new ApiBreedResponseModel();

			model.SetProperties(dtoBreed.Id, dtoBreed.Name, dtoBreed.SpeciesId);

			return model;
		}

		public virtual List<ApiBreedResponseModel> MapDTOToModel(
			List<DTOBreed> dtos)
		{
			List<ApiBreedResponseModel> response = new List<ApiBreedResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ddeb442548d7c5293eabc8ab7672d6dc</Hash>
</Codenesium>*/