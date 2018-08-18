using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALStoreMapper
	{
		Store MapBOToEF(
			BOStore bo);

		BOStore MapEFToBO(
			Store efStore);

		List<BOStore> MapEFToBO(
			List<Store> records);
	}
}

/*<Codenesium>
    <Hash>dfbfb348fdadc407983f12bb7d256ec1</Hash>
</Codenesium>*/