using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALStateMapper
	{
		State MapBOToEF(
			BOState bo);

		BOState MapEFToBO(
			State efState);

		List<BOState> MapEFToBO(
			List<State> records);
	}
}

/*<Codenesium>
    <Hash>211da6b412c86740347eea021b389131</Hash>
</Codenesium>*/