using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALEmployeeMapper
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
    <Hash>820647f1999de16752da82603803fd15</Hash>
</Codenesium>*/