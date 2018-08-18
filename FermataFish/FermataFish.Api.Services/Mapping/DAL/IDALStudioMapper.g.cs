using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALStudioMapper
	{
		Studio MapBOToEF(
			BOStudio bo);

		BOStudio MapEFToBO(
			Studio efStudio);

		List<BOStudio> MapEFToBO(
			List<Studio> records);
	}
}

/*<Codenesium>
    <Hash>dad2c33b2fb1a2b2e51fb45cf80de8b4</Hash>
</Codenesium>*/