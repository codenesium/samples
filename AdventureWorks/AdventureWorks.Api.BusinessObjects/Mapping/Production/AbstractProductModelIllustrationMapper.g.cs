using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductModelIllustrationMapper
	{
		public virtual DTOProductModelIllustration MapModelToDTO(
			int productModelID,
			ApiProductModelIllustrationRequestModel model
			)
		{
			DTOProductModelIllustration dtoProductModelIllustration = new DTOProductModelIllustration();

			dtoProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
			return dtoProductModelIllustration;
		}

		public virtual ApiProductModelIllustrationResponseModel MapDTOToModel(
			DTOProductModelIllustration dtoProductModelIllustration)
		{
			if (dtoProductModelIllustration == null)
			{
				return null;
			}

			var model = new ApiProductModelIllustrationResponseModel();

			model.SetProperties(dtoProductModelIllustration.IllustrationID, dtoProductModelIllustration.ModifiedDate, dtoProductModelIllustration.ProductModelID);

			return model;
		}

		public virtual List<ApiProductModelIllustrationResponseModel> MapDTOToModel(
			List<DTOProductModelIllustration> dtos)
		{
			List<ApiProductModelIllustrationResponseModel> response = new List<ApiProductModelIllustrationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5cebf62d2c8c8d9ffc2828e8f4c87b9b</Hash>
</Codenesium>*/