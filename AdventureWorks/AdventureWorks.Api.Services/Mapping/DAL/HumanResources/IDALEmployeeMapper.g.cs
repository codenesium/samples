using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALEmployeeMapper
	{
		Employee MapBOToEF(
			BOEmployee bo);

		BOEmployee MapEFToBO(
			Employee efEmployee);

		List<BOEmployee> MapEFToBO(
			List<Employee> records);
	}
}

/*<Codenesium>
    <Hash>39a09db13dab5126ccf626a23766945a</Hash>
</Codenesium>*/