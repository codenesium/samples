using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALShiftMapper
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
    <Hash>c760dca17d9f894fc643a3139eccde76</Hash>
</Codenesium>*/