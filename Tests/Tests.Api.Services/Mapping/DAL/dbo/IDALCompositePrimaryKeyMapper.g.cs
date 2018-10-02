using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALCompositePrimaryKeyMapper
	{
		CompositePrimaryKey MapBOToEF(
			BOCompositePrimaryKey bo);

		BOCompositePrimaryKey MapEFToBO(
			CompositePrimaryKey efCompositePrimaryKey);

		List<BOCompositePrimaryKey> MapEFToBO(
			List<CompositePrimaryKey> records);
	}
}

/*<Codenesium>
    <Hash>ebce39bede2c6f19b69a9bb6782ed5f0</Hash>
</Codenesium>*/