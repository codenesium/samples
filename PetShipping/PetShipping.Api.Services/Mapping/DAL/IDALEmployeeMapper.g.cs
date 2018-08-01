using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>c78d4b9f298f5d4ae1b94361f3203044</Hash>
</Codenesium>*/