using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALEmployeeDepartmentHistoryMapper
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
    <Hash>e996a21d519b14225827c12666ed0f7e</Hash>
</Codenesium>*/