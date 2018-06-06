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
			BOSpaceXSpaceFeature boSpaceXSpaceFeature = new BOSpaceXSpaceFeature();

			boSpaceXSpaceFeature.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
			return boSpaceXSpaceFeature;
		}

		public virtual ApiSpaceXSpaceFeatureResponseModel MapBOToModel(
			BOSpaceXSpaceFeature boSpaceXSpaceFeature)
		{
			var model = new ApiSpaceXSpaceFeatureResponseModel();

			model.SetProperties(boSpaceXSpaceFeature.Id, boSpaceXSpaceFeature.SpaceFeatureId, boSpaceXSpaceFeature.SpaceId);

			return model;
		}

		public virtual List<ApiSpaceXSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceXSpaceFeature> items)
		{
			List<ApiSpaceXSpaceFeatureResponseModel> response = new List<ApiSpaceXSpaceFeatureResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de45a9968263e059c150979b875abbfa</Hash>
</Codenesium>*/