using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractSpaceFeatureMapper
	{
		public virtual BOSpaceFeature MapModelToBO(
			int id,
			ApiSpaceFeatureServerRequestModel model
			)
		{
			BOSpaceFeature boSpaceFeature = new BOSpaceFeature();
			boSpaceFeature.SetProperties(
				id,
				model.Name);
			return boSpaceFeature;
		}

		public virtual ApiSpaceFeatureServerResponseModel MapBOToModel(
			BOSpaceFeature boSpaceFeature)
		{
			var model = new ApiSpaceFeatureServerResponseModel();

			model.SetProperties(boSpaceFeature.Id, boSpaceFeature.Name);

			return model;
		}

		public virtual List<ApiSpaceFeatureServerResponseModel> MapBOToModel(
			List<BOSpaceFeature> items)
		{
			List<ApiSpaceFeatureServerResponseModel> response = new List<ApiSpaceFeatureServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1b9ba7172d96401d395aa8246b40215b</Hash>
</Codenesium>*/