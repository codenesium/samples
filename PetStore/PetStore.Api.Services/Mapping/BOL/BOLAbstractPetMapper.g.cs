using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPetMapper
	{
		public virtual BOPet MapModelToBO(
			int id,
			ApiPetRequestModel model
			)
		{
			BOPet BOPet = new BOPet();

			BOPet.SetProperties(
				id,
				model.AcquiredDate,
				model.BreedId,
				model.Description,
				model.PenId,
				model.Price,
				model.SpeciesId);
			return BOPet;
		}

		public virtual ApiPetResponseModel MapBOToModel(
			BOPet BOPet)
		{
			if (BOPet == null)
			{
				return null;
			}

			var model = new ApiPetResponseModel();

			model.SetProperties(BOPet.AcquiredDate, BOPet.BreedId, BOPet.Description, BOPet.Id, BOPet.PenId, BOPet.Price, BOPet.SpeciesId);

			return model;
		}

		public virtual List<ApiPetResponseModel> MapBOToModel(
			List<BOPet> BOs)
		{
			List<ApiPetResponseModel> response = new List<ApiPetResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>02faf2e11b53f0f7c8ef17bf432e8294</Hash>
</Codenesium>*/