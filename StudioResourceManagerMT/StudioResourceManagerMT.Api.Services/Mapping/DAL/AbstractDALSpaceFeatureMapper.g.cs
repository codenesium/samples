using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALSpaceFeatureMapper
	{
		public virtual SpaceFeature MapModelToEntity(
			int id,
			ApiSpaceFeatureServerRequestModel model
			)
		{
			SpaceFeature item = new SpaceFeature();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiSpaceFeatureServerResponseModel MapEntityToModel(
			SpaceFeature item)
		{
			var model = new ApiSpaceFeatureServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiSpaceFeatureServerResponseModel> MapEntityToModel(
			List<SpaceFeature> items)
		{
			List<ApiSpaceFeatureServerResponseModel> response = new List<ApiSpaceFeatureServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>320085a72b52c35b1c99e470f1b6a9cd</Hash>
</Codenesium>*/