using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractBreedMapper
	{
		public virtual BOBreed MapModelToBO(
			int id,
			ApiBreedServerRequestModel model
			)
		{
			BOBreed boBreed = new BOBreed();
			boBreed.SetProperties(
				id,
				model.Name,
				model.SpeciesId);
			return boBreed;
		}

		public virtual ApiBreedServerResponseModel MapBOToModel(
			BOBreed boBreed)
		{
			var model = new ApiBreedServerResponseModel();

			model.SetProperties(boBreed.Id, boBreed.Name, boBreed.SpeciesId);

			return model;
		}

		public virtual List<ApiBreedServerResponseModel> MapBOToModel(
			List<BOBreed> items)
		{
			List<ApiBreedServerResponseModel> response = new List<ApiBreedServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>759aa8261390fda629eb5fcd718d5f79</Hash>
</Codenesium>*/