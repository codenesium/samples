using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>aa866a1fb304a60b08c64dd572838359</Hash>
</Codenesium>*/