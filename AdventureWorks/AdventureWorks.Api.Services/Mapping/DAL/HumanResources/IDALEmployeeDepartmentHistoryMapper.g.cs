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
    <Hash>6e8912921ece5a96e76b7261178f2093</Hash>
</Codenesium>*/