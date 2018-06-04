using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractSpeciesMapper
	{
		public virtual BOSpecies MapModelToBO(
			int id,
			ApiSpeciesRequestModel model
			)
		{
			BOSpecies BOSpecies = new BOSpecies();

			BOSpecies.SetProperties(
				id,
				model.Name);
			return BOSpecies;
		}

		public virtual ApiSpeciesResponseModel MapBOToModel(
			BOSpecies BOSpecies)
		{
			if (BOSpecies == null)
			{
				return null;
			}

			var model = new ApiSpeciesResponseModel();

			model.SetProperties(BOSpecies.Id, BOSpecies.Name);

			return model;
		}

		public virtual List<ApiSpeciesResponseModel> MapBOToModel(
			List<BOSpecies> BOs)
		{
			List<ApiSpeciesResponseModel> response = new List<ApiSpeciesResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c7a8a8ebc26fd0a0ed18555f4994a251</Hash>
</Codenesium>*/