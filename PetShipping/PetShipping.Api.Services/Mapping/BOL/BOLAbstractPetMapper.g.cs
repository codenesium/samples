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
			BOPet BOPet = new BOPet();

			BOPet.SetProperties(
				id,
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
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

			model.SetProperties(BOPet.BreedId, BOPet.ClientId, BOPet.Id, BOPet.Name, BOPet.Weight);

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
    <Hash>20c81232d9b7d8b37abd815c16aedb6e</Hash>
</Codenesium>*/