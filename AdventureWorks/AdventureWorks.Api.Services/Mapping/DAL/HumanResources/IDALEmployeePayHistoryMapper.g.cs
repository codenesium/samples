using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>0232e05147c74988af22798abd6e6a02</Hash>
</Codenesium>*/