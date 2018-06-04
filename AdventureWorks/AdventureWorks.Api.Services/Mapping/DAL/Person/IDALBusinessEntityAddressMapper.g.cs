using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>3b2dadb01b7e0d3026437a8732093622</Hash>
</Codenesium>*/