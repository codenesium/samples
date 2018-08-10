using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBusinessEntityMapper
	{
		BusinessEntity MapBOToEF(
			BOBusinessEntity bo);

		BOBusinessEntity MapEFToBO(
			BusinessEntity efBusinessEntity);

		List<BOBusinessEntity> MapEFToBO(
			List<BusinessEntity> records);
	}
}

/*<Codenesium>
    <Hash>58534a7bc3e5ee0af2c10973a6c1f5a2</Hash>
</Codenesium>*/