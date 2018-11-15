using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractSpeciesMapper
	{
		public virtual BOSpecies MapModelToBO(
			int id,
			ApiSpeciesServerRequestModel model
			)
		{
			BOSpecies boSpecies = new BOSpecies();
			boSpecies.SetProperties(
				id,
				model.Name);
			return boSpecies;
		}

		public virtual ApiSpeciesServerResponseModel MapBOToModel(
			BOSpecies boSpecies)
		{
			var model = new ApiSpeciesServerResponseModel();

			model.SetProperties(boSpecies.Id, boSpecies.Name);

			return model;
		}

		public virtual List<ApiSpeciesServerResponseModel> MapBOToModel(
			List<BOSpecies> items)
		{
			List<ApiSpeciesServerResponseModel> response = new List<ApiSpeciesServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>77a82fca73c6d14ce2f41c107b772152</Hash>
</Codenesium>*/