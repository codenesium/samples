using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShiftMapper
	{
		Shift MapBOToEF(
			BOShift bo);

		BOShift MapEFToBO(
			Shift efShift);

		List<BOShift> MapEFToBO(
			List<Shift> records);
	}
}

/*<Codenesium>
    <Hash>58dda18638f905b4b93a683aab1eb632</Hash>
</Codenesium>*/