using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALVendorMapper
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
    <Hash>a412636b5e173bac55f35c9138f37871</Hash>
</Codenesium>*/