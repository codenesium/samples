using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>782b0ed60adc36a0d96ffc319a8353b0</Hash>
</Codenesium>*/