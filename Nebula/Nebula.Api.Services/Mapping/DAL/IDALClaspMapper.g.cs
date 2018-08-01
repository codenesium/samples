using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IDALClaspMapper
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
    <Hash>f1c48a70aff51b059982f2cde3d0cec8</Hash>
</Codenesium>*/