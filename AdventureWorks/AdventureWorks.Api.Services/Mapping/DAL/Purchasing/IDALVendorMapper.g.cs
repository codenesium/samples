using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>7e0772cf804e9adae79916e9e614d8e3</Hash>
</Codenesium>*/