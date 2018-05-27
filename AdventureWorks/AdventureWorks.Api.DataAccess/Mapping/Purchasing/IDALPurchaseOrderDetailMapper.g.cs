using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPurchaseOrderDetailMapper
	{
		void MapDTOToEF(
			int purchaseOrderID,
			DTOPurchaseOrderDetail dto,
			PurchaseOrderDetail efPurchaseOrderDetail);

		DTOPurchaseOrderDetail MapEFToDTO(
			PurchaseOrderDetail efPurchaseOrderDetail);
	}
}

/*<Codenesium>
    <Hash>8f6ee56aee39b1d2ec761b5482e91b0d</Hash>
</Codenesium>*/