using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductVendorMapper
	{
		public virtual DTOProductVendor MapModelToDTO(
			int productID,
			ApiProductVendorRequestModel model
			)
		{
			DTOProductVendor dtoProductVendor = new DTOProductVendor();

			dtoProductVendor.SetProperties(
				productID,
				model.AverageLeadTime,
				model.BusinessEntityID,
				model.LastReceiptCost,
				model.LastReceiptDate,
				model.MaxOrderQty,
				model.MinOrderQty,
				model.ModifiedDate,
				model.OnOrderQty,
				model.StandardPrice,
				model.UnitMeasureCode);
			return dtoProductVendor;
		}

		public virtual ApiProductVendorResponseModel MapDTOToModel(
			DTOProductVendor dtoProductVendor)
		{
			if (dtoProductVendor == null)
			{
				return null;
			}

			var model = new ApiProductVendorResponseModel();

			model.SetProperties(dtoProductVendor.AverageLeadTime, dtoProductVendor.BusinessEntityID, dtoProductVendor.LastReceiptCost, dtoProductVendor.LastReceiptDate, dtoProductVendor.MaxOrderQty, dtoProductVendor.MinOrderQty, dtoProductVendor.ModifiedDate, dtoProductVendor.OnOrderQty, dtoProductVendor.ProductID, dtoProductVendor.StandardPrice, dtoProductVendor.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductVendorResponseModel> MapDTOToModel(
			List<DTOProductVendor> dtos)
		{
			List<ApiProductVendorResponseModel> response = new List<ApiProductVendorResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>78df2ac8b24c836fb375f7614a8369aa</Hash>
</Codenesium>*/