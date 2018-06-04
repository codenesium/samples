using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractBreedMapper
	{
		public virtual BOBreed MapModelToBO(
			int id,
			ApiBreedRequestModel model
			)
		{
			BOBreed BOBreed = new BOBreed();

			BOBreed.SetProperties(
				id,
				model.Name,
				model.SpeciesId);
			return BOBreed;
		}

		public virtual ApiBreedResponseModel MapBOToModel(
			BOBreed BOBreed)
		{
			if (BOBreed == null)
			{
				return null;
			}

			var model = new ApiBreedResponseModel();

			model.SetProperties(BOBreed.Id, BOBreed.Name, BOBreed.SpeciesId);

			return model;
		}

		public virtual List<ApiBreedResponseModel> MapBOToModel(
			List<BOBreed> BOs)
		{
			List<ApiBreedResponseModel> response = new List<ApiBreedResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>02348b5ef2691682be3cc863cf849ae7</Hash>
</Codenesium>*/