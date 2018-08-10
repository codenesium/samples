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
    <Hash>7672e4f145f30456d83fe352383b94bf</Hash>
</Codenesium>*/