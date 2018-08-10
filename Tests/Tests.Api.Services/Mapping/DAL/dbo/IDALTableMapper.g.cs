using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTableMapper
	{
		Table MapBOToEF(
			BOTable bo);

		BOTable MapEFToBO(
			Table efTable);

		List<BOTable> MapEFToBO(
			List<Table> records);
	}
}

/*<Codenesium>
    <Hash>65ec7ee22a9885147341f6cea1c57430</Hash>
</Codenesium>*/