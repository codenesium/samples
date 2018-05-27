using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSpaceXSpaceFeatureMapper
	{
		public virtual DTOSpaceXSpaceFeature MapModelToDTO(
			int id,
			ApiSpaceXSpaceFeatureRequestModel model
			)
		{
			DTOSpaceXSpaceFeature dtoSpaceXSpaceFeature = new DTOSpaceXSpaceFeature();

			dtoSpaceXSpaceFeature.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
			return dtoSpaceXSpaceFeature;
		}

		public virtual ApiSpaceXSpaceFeatureResponseModel MapDTOToModel(
			DTOSpaceXSpaceFeature dtoSpaceXSpaceFeature)
		{
			if (dtoSpaceXSpaceFeature == null)
			{
				return null;
			}

			var model = new ApiSpaceXSpaceFeatureResponseModel();

			model.SetProperties(dtoSpaceXSpaceFeature.Id, dtoSpaceXSpaceFeature.SpaceFeatureId, dtoSpaceXSpaceFeature.SpaceId);

			return model;
		}

		public virtual List<ApiSpaceXSpaceFeatureResponseModel> MapDTOToModel(
			List<DTOSpaceXSpaceFeature> dtos)
		{
			List<ApiSpaceXSpaceFeatureResponseModel> response = new List<ApiSpaceXSpaceFeatureResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6ecb1996bf9583a3d5019ee9ce6c17f4</Hash>
</Codenesium>*/