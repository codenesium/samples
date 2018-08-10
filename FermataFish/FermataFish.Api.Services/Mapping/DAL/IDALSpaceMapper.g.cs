using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALSpaceMapper
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
    <Hash>b972e053290efa9fd47ec747ffd41619</Hash>
</Codenesium>*/