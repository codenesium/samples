using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>43a0827bff61306ed10be7b15ef40775</Hash>
</Codenesium>*/