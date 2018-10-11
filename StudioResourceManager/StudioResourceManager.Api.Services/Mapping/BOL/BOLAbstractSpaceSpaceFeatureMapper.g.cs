using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractSpaceSpaceFeatureMapper
	{
		public virtual BOSpaceSpaceFeature MapModelToBO(
			int spaceId,
			ApiSpaceSpaceFeatureRequestModel model
			)
		{
			BOSpaceSpaceFeature boSpaceSpaceFeature = new BOSpaceSpaceFeature();
			boSpaceSpaceFeature.SetProperties(
				spaceId,
				model.SpaceFeatureId);
			return boSpaceSpaceFeature;
		}

		public virtual ApiSpaceSpaceFeatureResponseModel MapBOToModel(
			BOSpaceSpaceFeature boSpaceSpaceFeature)
		{
			var model = new ApiSpaceSpaceFeatureResponseModel();

			model.SetProperties(boSpaceSpaceFeature.SpaceId, boSpaceSpaceFeature.SpaceFeatureId);

			return model;
		}

		public virtual List<ApiSpaceSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceSpaceFeature> items)
		{
			List<ApiSpaceSpaceFeatureResponseModel> response = new List<ApiSpaceSpaceFeatureResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aae48df4f3de15004f3ed1d5f22d6b8f</Hash>
</Codenesium>*/