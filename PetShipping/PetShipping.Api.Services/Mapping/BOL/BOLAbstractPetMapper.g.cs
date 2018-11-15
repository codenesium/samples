using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
			return boPet;
		}

		public virtual ApiPetServerResponseModel MapBOToModel(
			BOPet boPet)
		{
			var model = new ApiPetServerResponseModel();

			model.SetProperties(boPet.Id, boPet.BreedId, boPet.ClientId, boPet.Name, boPet.Weight);

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
    <Hash>a8f59d71f2e607b86060d59540786dee</Hash>
</Codenesium>*/