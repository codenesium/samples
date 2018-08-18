using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesReasonMapper
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
    <Hash>2ab4eb15246c5a5ce385f762d554b2a9</Hash>
</Codenesium>*/