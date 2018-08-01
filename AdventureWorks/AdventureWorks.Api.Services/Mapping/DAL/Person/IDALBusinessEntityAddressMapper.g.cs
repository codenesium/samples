using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALBusinessEntityAddressMapper
	{
		BusinessEntityAddress MapBOToEF(
			BOBusinessEntityAddress bo);

		BOBusinessEntityAddress MapEFToBO(
			BusinessEntityAddress efBusinessEntityAddress);

		List<BOBusinessEntityAddress> MapEFToBO(
			List<BusinessEntityAddress> records);
	}
}

/*<Codenesium>
    <Hash>9f275959fc8081a6eb239fe1ddfb8078</Hash>
</Codenesium>*/