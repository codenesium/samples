using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALBusinessEntityContactMapper
	{
		BusinessEntityContact MapBOToEF(
			BOBusinessEntityContact bo);

		BOBusinessEntityContact MapEFToBO(
			BusinessEntityContact efBusinessEntityContact);

		List<BOBusinessEntityContact> MapEFToBO(
			List<BusinessEntityContact> records);
	}
}

/*<Codenesium>
    <Hash>bf67a4600fae9ea6873df8402f9310c8</Hash>
</Codenesium>*/