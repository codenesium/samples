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
    <Hash>fb55dbc6dccafd0812ef17e6136bba3f</Hash>
</Codenesium>*/