using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALPersonRefMapper
	{
		PersonRef MapBOToEF(
			BOPersonRef bo);

		BOPersonRef MapEFToBO(
			PersonRef efPersonRef);

		List<BOPersonRef> MapEFToBO(
			List<PersonRef> records);
	}
}

/*<Codenesium>
    <Hash>7d216a3e57386d2a0c26c34303e725af</Hash>
</Codenesium>*/