using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductModelMapper
	{
		public virtual ProductModel MapModelToBO(
			int productModelID,
			ApiProductModelServerRequestModel model
			)
		{
			ProductModel item = new ProductModel();
			item.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instruction,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return item;
		}

		public virtual ApiProductModelServerResponseModel MapBOToModel(
			ProductModel item)
		{
			var model = new ApiProductModelServerResponseModel();

			model.SetProperties(item.ProductModelID, item.CatalogDescription, item.Instruction, item.ModifiedDate, item.Name, item.Rowguid);

			return model;
		}

		public virtual List<ApiProductModelServerResponseModel> MapBOToModel(
			List<ProductModel> items)
		{
			List<ApiProductModelServerResponseModel> response = new List<ApiProductModelServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>77d5fe067d0f6cfa1c3bf65b78bc5df1</Hash>
</Codenesium>*/