using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>342ecf78c4b0b7463fafb1c732a899be</Hash>
</Codenesium>*/