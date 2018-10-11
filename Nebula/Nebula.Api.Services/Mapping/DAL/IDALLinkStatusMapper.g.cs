using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkStatusMapper
	{
		LinkStatus MapBOToEF(
			BOLinkStatus bo);

		BOLinkStatus MapEFToBO(
			LinkStatus efLinkStatus);

		List<BOLinkStatus> MapEFToBO(
			List<LinkStatus> records);
	}
}

/*<Codenesium>
    <Hash>8d7ec7d42bb4fa43036482f3fdf9dcb8</Hash>
</Codenesium>*/