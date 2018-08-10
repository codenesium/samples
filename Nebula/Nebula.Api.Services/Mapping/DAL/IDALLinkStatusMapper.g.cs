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
    <Hash>d8b6e510d77cce6808d37dcccd7c2f93</Hash>
</Codenesium>*/