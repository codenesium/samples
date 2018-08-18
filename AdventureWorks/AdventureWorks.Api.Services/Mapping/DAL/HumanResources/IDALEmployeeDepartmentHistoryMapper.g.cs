using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALEmployeeDepartmentHistoryMapper
	{
		EmployeeDepartmentHistory MapBOToEF(
			BOEmployeeDepartmentHistory bo);

		BOEmployeeDepartmentHistory MapEFToBO(
			EmployeeDepartmentHistory efEmployeeDepartmentHistory);

		List<BOEmployeeDepartmentHistory> MapEFToBO(
			List<EmployeeDepartmentHistory> records);
	}
}

/*<Codenesium>
    <Hash>0e23d0ef340e3cde37b6c573c69c1c10</Hash>
</Codenesium>*/