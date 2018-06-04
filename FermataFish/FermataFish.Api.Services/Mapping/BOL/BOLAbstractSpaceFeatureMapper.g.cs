using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractSpaceFeatureMapper
	{
		public virtual BOSpaceFeature MapModelToBO(
			int id,
			ApiSpaceFeatureRequestModel model
			)
		{
			BOSpaceFeature BOSpaceFeature = new BOSpaceFeature();

			BOSpaceFeature.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return BOSpaceFeature;
		}

		public virtual ApiSpaceFeatureResponseModel MapBOToModel(
			BOSpaceFeature BOSpaceFeature)
		{
			if (BOSpaceFeature == null)
			{
				return null;
			}

			var model = new ApiSpaceFeatureResponseModel();

			model.SetProperties(BOSpaceFeature.Id, BOSpaceFeature.Name, BOSpaceFeature.StudioId);

			return model;
		}

		public virtual List<ApiSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceFeature> BOs)
		{
			List<ApiSpaceFeatureResponseModel> response = new List<ApiSpaceFeatureResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8c9e7e9c5659f0b90c4e6b329026ae2c</Hash>
</Codenesium>*/