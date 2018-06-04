using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALErrorLogMapper
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
    <Hash>954ec831647d8de450162f5f870bedb2</Hash>
</Codenesium>*/