using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALBusinessEntityMapper
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
    <Hash>8a29fb1b6b31272c4dd30c22acfd8cbb</Hash>
</Codenesium>*/