using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>b353613aa4870766a5269509d4ff41d8</Hash>
</Codenesium>*/