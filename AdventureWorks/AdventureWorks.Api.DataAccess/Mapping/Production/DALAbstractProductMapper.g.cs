using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProduct dto,
			Product efProduct)
		{
			efProduct.SetProperties(
				productID,
				dto.@Class,
				dto.Color,
				dto.DaysToManufacture,
				dto.DiscontinuedDate,
				dto.FinishedGoodsFlag,
				dto.ListPrice,
				dto.MakeFlag,
				dto.ModifiedDate,
				dto.Name,
				dto.ProductLine,
				dto.ProductModelID,
				dto.ProductNumber,
				dto.ProductSubcategoryID,
				dto.ReorderPoint,
				dto.Rowguid,
				dto.SafetyStockLevel,
				dto.SellEndDate,
				dto.SellStartDate,
				dto.Size,
				dto.SizeUnitMeasureCode,
				dto.StandardCost,
				dto.Style,
				dto.Weight,
				dto.WeightUnitMeasureCode);
		}

		public virtual DTOProduct MapEFToDTO(
			Product ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProduct();

			dto.SetProperties(
				ef.ProductID,
				ef.@Class,
				ef.Color,
				ef.DaysToManufacture,
				ef.DiscontinuedDate,
				ef.FinishedGoodsFlag,
				ef.ListPrice,
				ef.MakeFlag,
				ef.ModifiedDate,
				ef.Name,
				ef.ProductLine,
				ef.ProductModelID,
				ef.ProductNumber,
				ef.ProductSubcategoryID,
				ef.ReorderPoint,
				ef.Rowguid,
				ef.SafetyStockLevel,
				ef.SellEndDate,
				ef.SellStartDate,
				ef.Size,
				ef.SizeUnitMeasureCode,
				ef.StandardCost,
				ef.Style,
				ef.Weight,
				ef.WeightUnitMeasureCode);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>bcbd8786165d6b0209f74aececf20dcc</Hash>
</Codenesium>*/