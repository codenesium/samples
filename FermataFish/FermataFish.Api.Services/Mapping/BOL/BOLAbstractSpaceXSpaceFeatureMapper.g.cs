using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractSpaceXSpaceFeatureMapper
	{
		public virtual BOSpaceXSpaceFeature MapModelToBO(
			int id,
			ApiSpaceXSpaceFeatureRequestModel model
			)
		{
			BOSpaceXSpaceFeature BOSpaceXSpaceFeature = new BOSpaceXSpaceFeature();

			BOSpaceXSpaceFeature.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
			return BOSpaceXSpaceFeature;
		}

		public virtual ApiSpaceXSpaceFeatureResponseModel MapBOToModel(
			BOSpaceXSpaceFeature BOSpaceXSpaceFeature)
		{
			if (BOSpaceXSpaceFeature == null)
			{
				return null;
			}

			var model = new ApiSpaceXSpaceFeatureResponseModel();

			model.SetProperties(BOSpaceXSpaceFeature.Id, BOSpaceXSpaceFeature.SpaceFeatureId, BOSpaceXSpaceFeature.SpaceId);

			return model;
		}

		public virtual List<ApiSpaceXSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceXSpaceFeature> BOs)
		{
			List<ApiSpaceXSpaceFeatureResponseModel> response = new List<ApiSpaceXSpaceFeatureResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4a9a8d3b94a8f23dde6a29ae99436d4e</Hash>
</Codenesium>*/