using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
				model.SpaceId,
				model.StudioId);
			return boSpaceXSpaceFeature;
		}

		public virtual ApiSpaceXSpaceFeatureResponseModel MapBOToModel(
			BOSpaceXSpaceFeature boSpaceXSpaceFeature)
		{
			var model = new ApiSpaceXSpaceFeatureResponseModel();

			model.SetProperties(boSpaceXSpaceFeature.Id, boSpaceXSpaceFeature.SpaceFeatureId, boSpaceXSpaceFeature.SpaceId, boSpaceXSpaceFeature.StudioId);

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
    <Hash>44c0f3cf28502a96e098c4f5eff82803</Hash>
</Codenesium>*/