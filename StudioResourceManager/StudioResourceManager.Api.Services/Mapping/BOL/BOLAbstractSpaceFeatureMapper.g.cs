using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractSpaceFeatureMapper
	{
		public virtual BOSpaceFeature MapModelToBO(
			int id,
			ApiSpaceFeatureRequestModel model
			)
		{
			BOSpaceFeature boSpaceFeature = new BOSpaceFeature();
			boSpaceFeature.SetProperties(
				id,
				model.Name);
			return boSpaceFeature;
		}

		public virtual ApiSpaceFeatureResponseModel MapBOToModel(
			BOSpaceFeature boSpaceFeature)
		{
			var model = new ApiSpaceFeatureResponseModel();

			model.SetProperties(boSpaceFeature.Id, boSpaceFeature.Name);

			return model;
		}

		public virtual List<ApiSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceFeature> items)
		{
			List<ApiSpaceFeatureResponseModel> response = new List<ApiSpaceFeatureResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>55cfdcaddc53e045a78b7a74d16a004b</Hash>
</Codenesium>*/