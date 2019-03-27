using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALSpaceSpaceFeatureMapper
	{
		public virtual SpaceSpaceFeature MapModelToEntity(
			int spaceId,
			ApiSpaceSpaceFeatureServerRequestModel model
			)
		{
			SpaceSpaceFeature item = new SpaceSpaceFeature();
			item.SetProperties(
				spaceId,
				model.SpaceFeatureId);
			return item;
		}

		public virtual ApiSpaceSpaceFeatureServerResponseModel MapEntityToModel(
			SpaceSpaceFeature item)
		{
			var model = new ApiSpaceSpaceFeatureServerResponseModel();

			model.SetProperties(item.SpaceId,
			                    item.SpaceFeatureId);
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
    <Hash>19e2b935d82cd70c0d2cd2f5a3027b8a</Hash>
</Codenesium>*/