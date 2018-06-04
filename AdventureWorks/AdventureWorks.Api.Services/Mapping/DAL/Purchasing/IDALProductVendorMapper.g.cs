using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>e52b93487c45311b62469f4153e40348</Hash>
</Codenesium>*/