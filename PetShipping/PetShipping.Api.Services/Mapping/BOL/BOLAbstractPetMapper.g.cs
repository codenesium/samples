using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPetMapper
	{
		public virtual BOPet MapModelToBO(
			int id,
			ApiPetRequestModel model
			)
		{
			BOPet boPet = new BOPet();
			boPet.SetProperties(
				id,
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
			return boPet;
		}

		public virtual ApiPetResponseModel MapBOToModel(
			BOPet boPet)
		{
			var model = new ApiPetResponseModel();

			model.SetProperties(boPet.Id, boPet.BreedId, boPet.ClientId, boPet.Name, boPet.Weight);

			return model;
		}

		public virtual List<ApiPetResponseModel> MapBOToModel(
			List<BOPet> items)
		{
			List<ApiPetResponseModel> response = new List<ApiPetResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d1c9c27635d257dc2382638dc859360e</Hash>
</Codenesium>*/