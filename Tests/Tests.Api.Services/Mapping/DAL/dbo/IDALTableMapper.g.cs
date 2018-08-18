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
    <Hash>f9a81f7568cb5c0a06d7b187274346e1</Hash>
</Codenesium>*/