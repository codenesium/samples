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
    <Hash>763a025f39fb4687eca2e88ee17b96f9</Hash>
</Codenesium>*/