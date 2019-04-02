using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALSpaceSpaceFeatureMapper
	{
		public virtual SpaceSpaceFeature MapModelToEntity(
			int id,
			ApiSpaceSpaceFeatureServerRequestModel model
			)
		{
			SpaceSpaceFeature item = new SpaceSpaceFeature();
			item.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
			return item;
		}

		public virtual ApiSpaceSpaceFeatureServerResponseModel MapEntityToModel(
			SpaceSpaceFeature item)
		{
			var model = new ApiSpaceSpaceFeatureServerResponseModel();

			model.SetProperties(item.Id,
			                    item.SpaceFeatureId,
			                    item.SpaceId);
			if (item.SpaceFeatureIdNavigation != null)
			{
				var spaceFeatureIdModel = new ApiSpaceFeatureServerResponseModel();
				spaceFeatureIdModel.SetProperties(
					item.SpaceFeatureIdNavigation.Id,
					item.SpaceFeatureIdNavigation.Name);

				model.SetSpaceFeatureIdNavigation(spaceFeatureIdModel);
			}

			if (item.SpaceIdNavigation != null)
			{
				var spaceIdModel = new ApiSpaceServerResponseModel();
				spaceIdModel.SetProperties(
					item.SpaceIdNavigation.Id,
					item.SpaceIdNavigation.Description,
					item.SpaceIdNavigation.Name);

				model.SetSpaceIdNavigation(spaceIdModel);
			}

			return model;
		}

		public virtual List<ApiSpaceSpaceFeatureServerResponseModel> MapEntityToModel(
			List<SpaceSpaceFeature> items)
		{
			List<ApiSpaceSpaceFeatureServerResponseModel> response = new List<ApiSpaceSpaceFeatureServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f0056d7eb4f5084bccf63ab45cbae68c</Hash>
</Codenesium>*/