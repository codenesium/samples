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
    <Hash>1cd399ef741f81c3fe33a709edc118e3</Hash>
</Codenesium>*/