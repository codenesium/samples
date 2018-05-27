using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesOrderDetailMapper
	{
		public virtual void MapDTOToEF(
			int salesOrderID,
			DTOSalesOrderDetail dto,
			SalesOrderDetail efSalesOrderDetail)
		{
			efSalesOrderDetail.SetProperties(
				salesOrderID,
				dto.CarrierTrackingNumber,
				dto.LineTotal,
				dto.ModifiedDate,
				dto.OrderQty,
				dto.ProductID,
				dto.Rowguid,
				dto.SalesOrderDetailID,
				dto.SpecialOfferID,
				dto.UnitPrice,
				dto.UnitPriceDiscount);
		}

		public virtual DTOSalesOrderDetail MapEFToDTO(
			SalesOrderDetail ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesOrderDetail();

			dto.SetProperties(
				ef.SalesOrderID,
				ef.CarrierTrackingNumber,
				ef.LineTotal,
				ef.ModifiedDate,
				ef.OrderQty,
				ef.ProductID,
				ef.Rowguid,
				ef.SalesOrderDetailID,
				ef.SpecialOfferID,
				ef.UnitPrice,
				ef.UnitPriceDiscount);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>36f02b769526d8d4aa468d264701dd8b</Hash>
</Codenesium>*/