using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>5713b969020534fa8e57947712f2e3c3</Hash>
</Codenesium>*/