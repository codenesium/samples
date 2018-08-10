using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALPersonMapper
	{
		Person MapBOToEF(
			BOPerson bo);

		BOPerson MapEFToBO(
			Person efPerson);

		List<BOPerson> MapEFToBO(
			List<Person> records);
	}
}

/*<Codenesium>
    <Hash>3f9860968d983351b47982c41e545df2</Hash>
</Codenesium>*/