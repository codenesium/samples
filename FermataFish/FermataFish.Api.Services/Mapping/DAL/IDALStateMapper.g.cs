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
    <Hash>fe486b0df8cfb8090376b00f0672196a</Hash>
</Codenesium>*/