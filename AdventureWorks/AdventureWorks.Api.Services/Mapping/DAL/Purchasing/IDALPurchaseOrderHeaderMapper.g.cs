using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALPurchaseOrderHeaderMapper
	{
		PurchaseOrderHeader MapBOToEF(
			BOPurchaseOrderHeader bo);

		BOPurchaseOrderHeader MapEFToBO(
			PurchaseOrderHeader efPurchaseOrderHeader);

		List<BOPurchaseOrderHeader> MapEFToBO(
			List<PurchaseOrderHeader> records);
	}
}

/*<Codenesium>
    <Hash>22268f843f99571c35b5e5ca5fb5072e</Hash>
</Codenesium>*/