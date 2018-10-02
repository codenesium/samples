using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkStatuMapper
	{
		LinkStatu MapBOToEF(
			BOLinkStatu bo);

		BOLinkStatu MapEFToBO(
			LinkStatu efLinkStatu);

		List<BOLinkStatu> MapEFToBO(
			List<LinkStatu> records);
	}
}

/*<Codenesium>
    <Hash>39d6727a4109ff4c90c826ecd427b95a</Hash>
</Codenesium>*/