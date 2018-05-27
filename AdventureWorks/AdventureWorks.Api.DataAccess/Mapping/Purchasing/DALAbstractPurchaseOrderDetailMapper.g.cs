using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPurchaseOrderDetailMapper
	{
		public virtual void MapDTOToEF(
			int purchaseOrderID,
			DTOPurchaseOrderDetail dto,
			PurchaseOrderDetail efPurchaseOrderDetail)
		{
			efPurchaseOrderDetail.SetProperties(
				purchaseOrderID,
				dto.DueDate,
				dto.LineTotal,
				dto.ModifiedDate,
				dto.OrderQty,
				dto.ProductID,
				dto.PurchaseOrderDetailID,
				dto.ReceivedQty,
				dto.RejectedQty,
				dto.StockedQty,
				dto.UnitPrice);
		}

		public virtual DTOPurchaseOrderDetail MapEFToDTO(
			PurchaseOrderDetail ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPurchaseOrderDetail();

			dto.SetProperties(
				ef.PurchaseOrderID,
				ef.DueDate,
				ef.LineTotal,
				ef.ModifiedDate,
				ef.OrderQty,
				ef.ProductID,
				ef.PurchaseOrderDetailID,
				ef.ReceivedQty,
				ef.RejectedQty,
				ef.StockedQty,
				ef.UnitPrice);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>37b3884b3cfd87e7f4d1cb23906222ac</Hash>
</Codenesium>*/