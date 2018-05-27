using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
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
				model.Name);
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

			model.SetProperties(dtoBreed.Id, dtoBreed.Name);

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
    <Hash>8fde2e02d6913b06db5152ae93f0aead</Hash>
</Codenesium>*/