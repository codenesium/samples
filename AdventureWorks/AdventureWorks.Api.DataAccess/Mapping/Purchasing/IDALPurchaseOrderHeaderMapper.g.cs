using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPurchaseOrderHeaderMapper
	{
		void MapDTOToEF(
			int purchaseOrderID,
			DTOPurchaseOrderHeader dto,
			PurchaseOrderHeader efPurchaseOrderHeader);

		DTOPurchaseOrderHeader MapEFToDTO(
			PurchaseOrderHeader efPurchaseOrderHeader);
	}
}

/*<Codenesium>
    <Hash>51fca2c1df0ecf1aae181192da47a91f</Hash>
</Codenesium>*/