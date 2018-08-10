using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductVendorMapper
	{
		ProductVendor MapBOToEF(
			BOProductVendor bo);

		BOProductVendor MapEFToBO(
			ProductVendor efProductVendor);

		List<BOProductVendor> MapEFToBO(
			List<ProductVendor> records);
	}
}

/*<Codenesium>
    <Hash>5e981215ec6ed07844c421a73a517a64</Hash>
</Codenesium>*/