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
    <Hash>b99b161d544a12601ac1bfc028f54d78</Hash>
</Codenesium>*/