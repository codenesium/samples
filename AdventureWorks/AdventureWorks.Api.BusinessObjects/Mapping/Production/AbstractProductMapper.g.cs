using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductMapper
	{
		public virtual DTOProduct MapModelToDTO(
			int productID,
			ApiProductRequestModel model
			)
		{
			DTOProduct dtoProduct = new DTOProduct();

			dtoProduct.SetProperties(
				productID,
				model.@Class,
				model.Color,
				model.DaysToManufacture,
				model.DiscontinuedDate,
				model.FinishedGoodsFlag,
				model.ListPrice,
				model.MakeFlag,
				model.ModifiedDate,
				model.Name,
				model.ProductLine,
				model.ProductModelID,
				model.ProductNumber,
				model.ProductSubcategoryID,
				model.ReorderPoint,
				model.Rowguid,
				model.SafetyStockLevel,
				model.SellEndDate,
				model.SellStartDate,
				model.Size,
				model.SizeUnitMeasureCode,
				model.StandardCost,
				model.Style,
				model.Weight,
				model.WeightUnitMeasureCode);
			return dtoProduct;
		}

		public virtual ApiProductResponseModel MapDTOToModel(
			DTOProduct dtoProduct)
		{
			if (dtoProduct == null)
			{
				return null;
			}

			var model = new ApiProductResponseModel();

			model.SetProperties(dtoProduct.@Class, dtoProduct.Color, dtoProduct.DaysToManufacture, dtoProduct.DiscontinuedDate, dtoProduct.FinishedGoodsFlag, dtoProduct.ListPrice, dtoProduct.MakeFlag, dtoProduct.ModifiedDate, dtoProduct.Name, dtoProduct.ProductID, dtoProduct.ProductLine, dtoProduct.ProductModelID, dtoProduct.ProductNumber, dtoProduct.ProductSubcategoryID, dtoProduct.ReorderPoint, dtoProduct.Rowguid, dtoProduct.SafetyStockLevel, dtoProduct.SellEndDate, dtoProduct.SellStartDate, dtoProduct.Size, dtoProduct.SizeUnitMeasureCode, dtoProduct.StandardCost, dtoProduct.Style, dtoProduct.Weight, dtoProduct.WeightUnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductResponseModel> MapDTOToModel(
			List<DTOProduct> dtos)
		{
			List<ApiProductResponseModel> response = new List<ApiProductResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ce9b67f66245b399984a9655c5bccedc</Hash>
</Codenesium>*/