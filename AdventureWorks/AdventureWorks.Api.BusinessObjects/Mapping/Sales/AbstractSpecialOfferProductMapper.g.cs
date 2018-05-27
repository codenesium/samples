using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSpecialOfferProductMapper
	{
		public virtual DTOSpecialOfferProduct MapModelToDTO(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model
			)
		{
			DTOSpecialOfferProduct dtoSpecialOfferProduct = new DTOSpecialOfferProduct();

			dtoSpecialOfferProduct.SetProperties(
				specialOfferID,
				model.ModifiedDate,
				model.ProductID,
				model.Rowguid);
			return dtoSpecialOfferProduct;
		}

		public virtual ApiSpecialOfferProductResponseModel MapDTOToModel(
			DTOSpecialOfferProduct dtoSpecialOfferProduct)
		{
			if (dtoSpecialOfferProduct == null)
			{
				return null;
			}

			var model = new ApiSpecialOfferProductResponseModel();

			model.SetProperties(dtoSpecialOfferProduct.ModifiedDate, dtoSpecialOfferProduct.ProductID, dtoSpecialOfferProduct.Rowguid, dtoSpecialOfferProduct.SpecialOfferID);

			return model;
		}

		public virtual List<ApiSpecialOfferProductResponseModel> MapDTOToModel(
			List<DTOSpecialOfferProduct> dtos)
		{
			List<ApiSpecialOfferProductResponseModel> response = new List<ApiSpecialOfferProductResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3c1f2a506ba0e471aa5e7d35b163a517</Hash>
</Codenesium>*/