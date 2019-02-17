using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductDescriptionMapper
	{
		public virtual ProductDescription MapModelToEntity(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel model
			)
		{
			ProductDescription item = new ProductDescription();
			item.SetProperties(
				productDescriptionID,
				model.Description,
				model.ModifiedDate,
				model.Rowguid);
			return item;
		}

		public virtual ApiProductDescriptionServerResponseModel MapEntityToModel(
			ProductDescription item)
		{
			var model = new ApiProductDescriptionServerResponseModel();

			model.SetProperties(item.ProductDescriptionID,
			                    item.Description,
			                    item.ModifiedDate,
			                    item.Rowguid);

			return model;
		}

		public virtual List<ApiProductDescriptionServerResponseModel> MapEntityToModel(
			List<ProductDescription> items)
		{
			List<ApiProductDescriptionServerResponseModel> response = new List<ApiProductDescriptionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>376ca17e9a88b01b4ce2c9e567e8666b</Hash>
</Codenesium>*/