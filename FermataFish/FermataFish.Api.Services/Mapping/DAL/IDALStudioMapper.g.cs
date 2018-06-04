using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>01881baacd44232fff5f5ccb1b810252</Hash>
</Codenesium>*/