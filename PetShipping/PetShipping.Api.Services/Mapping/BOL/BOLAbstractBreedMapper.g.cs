using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractBreedMapper
	{
		public virtual BOBreed MapModelToBO(
			int id,
			ApiBreedRequestModel model
			)
		{
			BOBreed boBreed = new BOBreed();
			boBreed.SetProperties(
				id,
				model.Name,
				model.SpeciesId);
			return boBreed;
		}

		public virtual ApiBreedResponseModel MapBOToModel(
			BOBreed boBreed)
		{
			var model = new ApiBreedResponseModel();

			model.SetProperties(boBreed.Id, boBreed.Name, boBreed.SpeciesId);

			return model;
		}

		public virtual List<ApiBreedResponseModel> MapBOToModel(
			List<BOBreed> items)
		{
			List<ApiBreedResponseModel> response = new List<ApiBreedResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bdc233b16e19557ed1a67c614cffca81</Hash>
</Codenesium>*/