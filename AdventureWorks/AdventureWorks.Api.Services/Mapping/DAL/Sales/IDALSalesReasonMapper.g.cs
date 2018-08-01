using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesReasonMapper
	{
		SalesReason MapBOToEF(
			BOSalesReason bo);

		BOSalesReason MapEFToBO(
			SalesReason efSalesReason);

		List<BOSalesReason> MapEFToBO(
			List<SalesReason> records);
	}
}

/*<Codenesium>
    <Hash>c0b78b2a857bd298eeb0be12d04c1245</Hash>
</Codenesium>*/