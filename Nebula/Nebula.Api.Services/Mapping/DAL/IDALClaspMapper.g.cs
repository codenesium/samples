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
    <Hash>2a3466edd7e477ea18907d0db577b502</Hash>
</Codenesium>*/