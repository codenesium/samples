using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractSpaceSpaceFeatureMapper
	{
		public virtual BOSpaceSpaceFeature MapModelToBO(
			int id,
			ApiSpaceSpaceFeatureRequestModel model
			)
		{
			BOSpaceSpaceFeature boSpaceSpaceFeature = new BOSpaceSpaceFeature();
			boSpaceSpaceFeature.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
			return boSpaceSpaceFeature;
		}

		public virtual ApiSpaceSpaceFeatureResponseModel MapBOToModel(
			BOSpaceSpaceFeature boSpaceSpaceFeature)
		{
			var model = new ApiSpaceSpaceFeatureResponseModel();

			model.SetProperties(boSpaceSpaceFeature.Id, boSpaceSpaceFeature.SpaceFeatureId, boSpaceSpaceFeature.SpaceId);

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
    <Hash>c4b12328f5c681b7c117e06346c2bd23</Hash>
</Codenesium>*/