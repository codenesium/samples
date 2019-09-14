using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALSpaceSpaceFeatureMapper : IDALSpaceSpaceFeatureMapper
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
    <Hash>3ef49cdf359a058f5a66d8506dbf9c57</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/