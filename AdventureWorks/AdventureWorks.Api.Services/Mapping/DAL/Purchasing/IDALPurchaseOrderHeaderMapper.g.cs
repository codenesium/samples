using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>35d1ef6f11eabb8d639a9dd749dd883e</Hash>
</Codenesium>*/