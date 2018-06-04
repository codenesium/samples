using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALEmployeePayHistoryMapper
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
    <Hash>d09f806995deeb1307b57171d1e546d2</Hash>
</Codenesium>*/