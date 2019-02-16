using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductDescriptionMapper
	{
		public virtual ProductDescription MapModelToBO(
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

		public virtual ApiProductDescriptionServerResponseModel MapBOToModel(
			ProductDescription item)
		{
			var model = new ApiProductDescriptionServerResponseModel();

			model.SetProperties(item.ProductDescriptionID, item.Description, item.ModifiedDate, item.Rowguid);

			return model;
		}

		public virtual List<ApiProductDescriptionServerResponseModel> MapBOToModel(
			List<ProductDescription> items)
		{
			List<ApiProductDescriptionServerResponseModel> response = new List<ApiProductDescriptionServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e5fb99e44f4de68dd1f0791f4ad72390</Hash>
</Codenesium>*/