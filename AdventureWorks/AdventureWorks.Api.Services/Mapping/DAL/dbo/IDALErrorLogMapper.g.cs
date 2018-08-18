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
    <Hash>b2f96a9efeb67ec79c2c24e5f2bbe616</Hash>
</Codenesium>*/