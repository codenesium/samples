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
			BOProductModel boProductModel = new BOProductModel();

			boProductModel.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instructions,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return boProductModel;
		}

		public virtual ApiProductModelResponseModel MapBOToModel(
			BOProductModel boProductModel)
		{
			var model = new ApiProductModelResponseModel();

			model.SetProperties(boProductModel.CatalogDescription, boProductModel.Instructions, boProductModel.ModifiedDate, boProductModel.Name, boProductModel.ProductModelID, boProductModel.Rowguid);

			return model;
		}

		public virtual List<ApiProductModelResponseModel> MapBOToModel(
			List<BOProductModel> items)
		{
			List<ApiProductModelResponseModel> response = new List<ApiProductModelResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>25c537bf27d1e77e2c603fcce62cf8d9</Hash>
</Codenesium>*/