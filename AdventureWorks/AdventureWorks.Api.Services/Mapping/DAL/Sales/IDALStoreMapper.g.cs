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
    <Hash>69d146bb43c617a5d203db8c12e56808</Hash>
</Codenesium>*/