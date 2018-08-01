using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALPasswordMapper
	{
		Password MapBOToEF(
			BOPassword bo);

		BOPassword MapEFToBO(
			Password efPassword);

		List<BOPassword> MapEFToBO(
			List<Password> records);
	}
}

/*<Codenesium>
    <Hash>d3e48cbd93ad87e1e30479a696d42d31</Hash>
</Codenesium>*/