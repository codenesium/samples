using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductModelMapper
	{
		public virtual DTOProductModel MapModelToDTO(
			int productModelID,
			ApiProductModelRequestModel model
			)
		{
			DTOProductModel dtoProductModel = new DTOProductModel();

			dtoProductModel.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instructions,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return dtoProductModel;
		}

		public virtual ApiProductModelResponseModel MapDTOToModel(
			DTOProductModel dtoProductModel)
		{
			if (dtoProductModel == null)
			{
				return null;
			}

			var model = new ApiProductModelResponseModel();

			model.SetProperties(dtoProductModel.CatalogDescription, dtoProductModel.Instructions, dtoProductModel.ModifiedDate, dtoProductModel.Name, dtoProductModel.ProductModelID, dtoProductModel.Rowguid);

			return model;
		}

		public virtual List<ApiProductModelResponseModel> MapDTOToModel(
			List<DTOProductModel> dtos)
		{
			List<ApiProductModelResponseModel> response = new List<ApiProductModelResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ecb103b49aa0e0eba6b9ce8514f1c885</Hash>
</Codenesium>*/