using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPetMapper
	{
		public virtual DTOPet MapModelToDTO(
			int id,
			ApiPetRequestModel model
			)
		{
			DTOPet dtoPet = new DTOPet();

			dtoPet.SetProperties(
				id,
				model.AcquiredDate,
				model.BreedId,
				model.Description,
				model.PenId,
				model.Price,
				model.SpeciesId);
			return dtoPet;
		}

		public virtual ApiPetResponseModel MapDTOToModel(
			DTOPet dtoPet)
		{
			if (dtoPet == null)
			{
				return null;
			}

			var model = new ApiPetResponseModel();

			model.SetProperties(dtoPet.AcquiredDate, dtoPet.BreedId, dtoPet.Description, dtoPet.Id, dtoPet.PenId, dtoPet.Price, dtoPet.SpeciesId);

			return model;
		}

		public virtual List<ApiPetResponseModel> MapDTOToModel(
			List<DTOPet> dtos)
		{
			List<ApiPetResponseModel> response = new List<ApiPetResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a82a50cd1974ad5b0a1a9294f88046e</Hash>
</Codenesium>*/