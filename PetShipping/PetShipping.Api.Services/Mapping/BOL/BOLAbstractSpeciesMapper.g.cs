using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
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
    <Hash>a07ea7d88f23e759dd67171f9b94f297</Hash>
</Codenesium>*/