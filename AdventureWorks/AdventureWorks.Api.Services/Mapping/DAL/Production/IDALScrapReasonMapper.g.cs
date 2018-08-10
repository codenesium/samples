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
    <Hash>d424254632e29addbfbdb06524df6ca5</Hash>
</Codenesium>*/