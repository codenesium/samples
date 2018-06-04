using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>dca48f7630d94151e320db6c037a2b9a</Hash>
</Codenesium>*/