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
				model.SpaceFeatureId,
				model.IsDeleted);
			return boSpaceSpaceFeature;
		}

		public virtual ApiSpaceSpaceFeatureResponseModel MapBOToModel(
			BOSpaceSpaceFeature boSpaceSpaceFeature)
		{
			var model = new ApiSpaceSpaceFeatureResponseModel();

			model.SetProperties(boSpaceSpaceFeature.SpaceId, boSpaceSpaceFeature.SpaceFeatureId, boSpaceSpaceFeature.IsDeleted);

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
    <Hash>80f636a7e6ae2305a3295c14e373c00b</Hash>
</Codenesium>*/