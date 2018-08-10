using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALVendorMapper
	{
		Vendor MapBOToEF(
			BOVendor bo);

		BOVendor MapEFToBO(
			Vendor efVendor);

		List<BOVendor> MapEFToBO(
			List<Vendor> records);
	}
}

/*<Codenesium>
    <Hash>7861d5b21446af04999911a45c9d45b8</Hash>
</Codenesium>*/