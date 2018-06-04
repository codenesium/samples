using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALStoreMapper
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
    <Hash>714521c1553b9f099c29d90723086894</Hash>
</Codenesium>*/