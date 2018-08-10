using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>464540798c6569263c51b41d668590d8</Hash>
</Codenesium>*/