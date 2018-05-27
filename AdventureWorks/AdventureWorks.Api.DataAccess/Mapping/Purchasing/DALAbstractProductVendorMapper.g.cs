using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductVendorMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProductVendor dto,
			ProductVendor efProductVendor)
		{
			efProductVendor.SetProperties(
				productID,
				dto.AverageLeadTime,
				dto.BusinessEntityID,
				dto.LastReceiptCost,
				dto.LastReceiptDate,
				dto.MaxOrderQty,
				dto.MinOrderQty,
				dto.ModifiedDate,
				dto.OnOrderQty,
				dto.StandardPrice,
				dto.UnitMeasureCode);
		}

		public virtual DTOProductVendor MapEFToDTO(
			ProductVendor ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductVendor();

			dto.SetProperties(
				ef.ProductID,
				ef.AverageLeadTime,
				ef.BusinessEntityID,
				ef.LastReceiptCost,
				ef.LastReceiptDate,
				ef.MaxOrderQty,
				ef.MinOrderQty,
				ef.ModifiedDate,
				ef.OnOrderQty,
				ef.StandardPrice,
				ef.UnitMeasureCode);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>ba602777ca0ade6d4220cb5986d4c593</Hash>
</Codenesium>*/