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
    <Hash>5e5050fedf1185f517f68d73e9d68ec0</Hash>
</Codenesium>*/