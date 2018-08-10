using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALPersonRefMapper
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
    <Hash>f326d8784938c677a8b58a6e10a1e16e</Hash>
</Codenesium>*/