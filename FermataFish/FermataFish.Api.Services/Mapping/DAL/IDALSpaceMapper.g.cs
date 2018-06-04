using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IDALSpaceMapper
	{
		Space MapBOToEF(
			BOSpace bo);

		BOSpace MapEFToBO(
			Space efSpace);

		List<BOSpace> MapEFToBO(
			List<Space> records);
	}
}

/*<Codenesium>
    <Hash>4c3fcd84b050e9efd4b3d7bc7ecb4973</Hash>
</Codenesium>*/