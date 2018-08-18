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
    <Hash>31966f84cad04a994222d3cb9260425e</Hash>
</Codenesium>*/