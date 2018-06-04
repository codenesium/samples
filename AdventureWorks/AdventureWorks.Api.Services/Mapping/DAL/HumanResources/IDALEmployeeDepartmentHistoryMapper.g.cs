using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>92d3477600e65abfc1f27b8e799d4f07</Hash>
</Codenesium>*/