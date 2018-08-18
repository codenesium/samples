using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALScrapReasonMapper
	{
		ScrapReason MapBOToEF(
			BOScrapReason bo);

		BOScrapReason MapEFToBO(
			ScrapReason efScrapReason);

		List<BOScrapReason> MapEFToBO(
			List<ScrapReason> records);
	}
}

/*<Codenesium>
    <Hash>94e3c06f8e6040cf12271b4202f7e4f3</Hash>
</Codenesium>*/