using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductMapper
	{
		Product MapBOToEF(
			BOProduct bo);

		BOProduct MapEFToBO(
			Product efProduct);

		List<BOProduct> MapEFToBO(
			List<Product> records);
	}
}

/*<Codenesium>
    <Hash>320dcb4606d1b11de7dbaaf550fff2dc</Hash>
</Codenesium>*/