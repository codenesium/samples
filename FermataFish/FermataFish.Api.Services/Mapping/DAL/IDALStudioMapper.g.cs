using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALStudioMapper
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
    <Hash>79f6f1ee85292ca3d78c5c4c360549ef</Hash>
</Codenesium>*/