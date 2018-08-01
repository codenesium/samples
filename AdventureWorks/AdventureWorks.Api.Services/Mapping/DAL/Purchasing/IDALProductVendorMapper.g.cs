using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductVendorMapper
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
    <Hash>cc44ee754a26e7f7be8470df6cc709b9</Hash>
</Codenesium>*/