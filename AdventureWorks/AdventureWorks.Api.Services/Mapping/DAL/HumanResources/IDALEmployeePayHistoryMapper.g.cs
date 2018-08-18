using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALEmployeePayHistoryMapper
	{
		EmployeePayHistory MapBOToEF(
			BOEmployeePayHistory bo);

		BOEmployeePayHistory MapEFToBO(
			EmployeePayHistory efEmployeePayHistory);

		List<BOEmployeePayHistory> MapEFToBO(
			List<EmployeePayHistory> records);
	}
}

/*<Codenesium>
    <Hash>988231db573c70fdf4de345507a9efae</Hash>
</Codenesium>*/