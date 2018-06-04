using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IDALLinkStatusMapper
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
    <Hash>5fb2e8b1736beb87c2baa422f6dd7552</Hash>
</Codenesium>*/