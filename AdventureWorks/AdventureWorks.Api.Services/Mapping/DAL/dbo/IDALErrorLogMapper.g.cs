using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALErrorLogMapper
	{
		ErrorLog MapBOToEF(
			BOErrorLog bo);

		BOErrorLog MapEFToBO(
			ErrorLog efErrorLog);

		List<BOErrorLog> MapEFToBO(
			List<ErrorLog> records);
	}
}

/*<Codenesium>
    <Hash>3241de7b508c9d028e5177c4136b1bc3</Hash>
</Codenesium>*/