using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractPetMapper
	{
		public virtual BOPet MapModelToBO(
			int id,
			ApiPetServerRequestModel model
			)
		{
			BOPet boPet = new BOPet();
			boPet.SetProperties(
				id,
				model.AcquiredDate,
				model.BreedId,
				model.Description,
				model.PenId,
				model.Price,
				model.SpeciesId);
			return boPet;
		}

		public virtual ApiPetServerResponseModel MapBOToModel(
			BOPet boPet)
		{
			var model = new ApiPetServerResponseModel();

			model.SetProperties(boPet.Id, boPet.AcquiredDate, boPet.BreedId, boPet.Description, boPet.PenId, boPet.Price, boPet.SpeciesId);

			return model;
		}

		public virtual List<ApiPetServerResponseModel> MapBOToModel(
			List<BOPet> items)
		{
			List<ApiPetServerResponseModel> response = new List<ApiPetServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>32acd243873c25934dd4c0ebafbab4fa</Hash>
</Codenesium>*/