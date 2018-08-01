using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9380742f77294063fd0de7bfcc30a7c0</Hash>
</Codenesium>*/