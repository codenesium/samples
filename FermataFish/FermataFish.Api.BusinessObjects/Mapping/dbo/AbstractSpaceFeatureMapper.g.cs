using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSpaceFeatureMapper
	{
		public virtual DTOSpaceFeature MapModelToDTO(
			int id,
			ApiSpaceFeatureRequestModel model
			)
		{
			DTOSpaceFeature dtoSpaceFeature = new DTOSpaceFeature();

			dtoSpaceFeature.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return dtoSpaceFeature;
		}

		public virtual ApiSpaceFeatureResponseModel MapDTOToModel(
			DTOSpaceFeature dtoSpaceFeature)
		{
			if (dtoSpaceFeature == null)
			{
				return null;
			}

			var model = new ApiSpaceFeatureResponseModel();

			model.SetProperties(dtoSpaceFeature.Id, dtoSpaceFeature.Name, dtoSpaceFeature.StudioId);

			return model;
		}

		public virtual List<ApiSpaceFeatureResponseModel> MapDTOToModel(
			List<DTOSpaceFeature> dtos)
		{
			List<ApiSpaceFeatureResponseModel> response = new List<ApiSpaceFeatureResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>be48d20e9230a509fd9eb113f8b9181f</Hash>
</Codenesium>*/