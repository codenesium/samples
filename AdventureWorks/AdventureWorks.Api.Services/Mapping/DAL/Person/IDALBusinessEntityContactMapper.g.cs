using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBusinessEntityContactMapper
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
    <Hash>b9d2ece65d5ba1efba2e522f6fc5b290</Hash>
</Codenesium>*/