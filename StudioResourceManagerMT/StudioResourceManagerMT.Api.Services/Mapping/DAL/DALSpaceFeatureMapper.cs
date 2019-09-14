using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class DALSpaceFeatureMapper : IDALSpaceFeatureMapper
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
    <Hash>d70780bbe70a4c18ed09a0739f241c69</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/