using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
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
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
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

			model.SetProperties(dtoPet.BreedId, dtoPet.ClientId, dtoPet.Id, dtoPet.Name, dtoPet.Weight);

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
    <Hash>a50ec091be00fd29cb89225520ea0184</Hash>
</Codenesium>*/