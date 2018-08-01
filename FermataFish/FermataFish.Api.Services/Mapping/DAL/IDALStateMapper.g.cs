using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALStateMapper
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
    <Hash>8a106250bd25840da2c6e76efb46e53b</Hash>
</Codenesium>*/