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
				model.Name,
				model.IsDeleted);
			return boSpaceFeature;
		}

		public virtual ApiSpaceFeatureResponseModel MapBOToModel(
			BOSpaceFeature boSpaceFeature)
		{
			var model = new ApiSpaceFeatureResponseModel();

			model.SetProperties(boSpaceFeature.Id, boSpaceFeature.Name, boSpaceFeature.IsDeleted);

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
    <Hash>e2034dafcf7c36ef6a84510625e71a1d</Hash>
</Codenesium>*/