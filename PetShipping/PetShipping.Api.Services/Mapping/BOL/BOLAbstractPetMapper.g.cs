using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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

			model.SetProperties(boPet.BreedId, boPet.ClientId, boPet.Id, boPet.Name, boPet.Weight);

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
    <Hash>79186ea4f1c72da7842800ab156a8db0</Hash>
</Codenesium>*/