using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSpecialOfferProductMapper
	{
		public virtual BOSpecialOfferProduct MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model
			)
		{
			BOSpecialOfferProduct BOSpecialOfferProduct = new BOSpecialOfferProduct();

			BOSpecialOfferProduct.SetProperties(
				specialOfferID,
				model.ModifiedDate,
				model.ProductID,
				model.Rowguid);
			return BOSpecialOfferProduct;
		}

		public virtual ApiSpecialOfferProductResponseModel MapBOToModel(
			BOSpecialOfferProduct BOSpecialOfferProduct)
		{
			if (BOSpecialOfferProduct == null)
			{
				return null;
			}

			var model = new ApiSpecialOfferProductResponseModel();

			model.SetProperties(BOSpecialOfferProduct.ModifiedDate, BOSpecialOfferProduct.ProductID, BOSpecialOfferProduct.Rowguid, BOSpecialOfferProduct.SpecialOfferID);

			return model;
		}

		public virtual List<ApiSpecialOfferProductResponseModel> MapBOToModel(
			List<BOSpecialOfferProduct> BOs)
		{
			List<ApiSpecialOfferProductResponseModel> response = new List<ApiSpecialOfferProductResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e663c71970293503a7a9d4b345f2a0e2</Hash>
</Codenesium>*/