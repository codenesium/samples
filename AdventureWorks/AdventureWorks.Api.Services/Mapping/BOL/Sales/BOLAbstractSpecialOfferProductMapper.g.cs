using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSpecialOfferProductMapper
	{
		public virtual BOSpecialOfferProduct MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model
			)
		{
			BOSpecialOfferProduct boSpecialOfferProduct = new BOSpecialOfferProduct();
			boSpecialOfferProduct.SetProperties(
				specialOfferID,
				model.ModifiedDate,
				model.ProductID,
				model.Rowguid);
			return boSpecialOfferProduct;
		}

		public virtual ApiSpecialOfferProductResponseModel MapBOToModel(
			BOSpecialOfferProduct boSpecialOfferProduct)
		{
			var model = new ApiSpecialOfferProductResponseModel();

			model.SetProperties(boSpecialOfferProduct.SpecialOfferID, boSpecialOfferProduct.ModifiedDate, boSpecialOfferProduct.ProductID, boSpecialOfferProduct.Rowguid);

			return model;
		}

		public virtual List<ApiSpecialOfferProductResponseModel> MapBOToModel(
			List<BOSpecialOfferProduct> items)
		{
			List<ApiSpecialOfferProductResponseModel> response = new List<ApiSpecialOfferProductResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b727a205bce9f32048f8f1b07a7c320e</Hash>
</Codenesium>*/