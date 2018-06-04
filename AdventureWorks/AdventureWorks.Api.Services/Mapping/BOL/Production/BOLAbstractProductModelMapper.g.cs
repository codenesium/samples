using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelMapper
	{
		public virtual BOProductModel MapModelToBO(
			int productModelID,
			ApiProductModelRequestModel model
			)
		{
			BOProductModel BOProductModel = new BOProductModel();

			BOProductModel.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instructions,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return BOProductModel;
		}

		public virtual ApiProductModelResponseModel MapBOToModel(
			BOProductModel BOProductModel)
		{
			if (BOProductModel == null)
			{
				return null;
			}

			var model = new ApiProductModelResponseModel();

			model.SetProperties(BOProductModel.CatalogDescription, BOProductModel.Instructions, BOProductModel.ModifiedDate, BOProductModel.Name, BOProductModel.ProductModelID, BOProductModel.Rowguid);

			return model;
		}

		public virtual List<ApiProductModelResponseModel> MapBOToModel(
			List<BOProductModel> BOs)
		{
			List<ApiProductModelResponseModel> response = new List<ApiProductModelResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e33b582e21d144d436275ab05ef341b4</Hash>
</Codenesium>*/