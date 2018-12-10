using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALClaspMapper
	{
		Clasp MapBOToEF(
			BOClasp bo);

		BOClasp MapEFToBO(
			Clasp efClasp);

		List<BOClasp> MapEFToBO(
			List<Clasp> records);
	}
}

/*<Codenesium>
    <Hash>18f2b2100b9de9d4d6b7de31c95f0dc1</Hash>
</Codenesium>*/