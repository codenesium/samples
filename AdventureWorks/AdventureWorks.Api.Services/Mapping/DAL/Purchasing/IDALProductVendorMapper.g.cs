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
    <Hash>36965e23f90b6b81ff249ba9cbda8abc</Hash>
</Codenesium>*/