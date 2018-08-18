using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductDescriptionMapper
	{
		ProductDescription MapBOToEF(
			BOProductDescription bo);

		BOProductDescription MapEFToBO(
			ProductDescription efProductDescription);

		List<BOProductDescription> MapEFToBO(
			List<ProductDescription> records);
	}
}

/*<Codenesium>
    <Hash>35faee69dacbb7afbc916d0a2660bd1b</Hash>
</Codenesium>*/