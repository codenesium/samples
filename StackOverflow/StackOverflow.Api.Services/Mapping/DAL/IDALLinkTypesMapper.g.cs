using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALLinkTypesMapper
	{
		LinkTypes MapBOToEF(
			BOLinkTypes bo);

		BOLinkTypes MapEFToBO(
			LinkTypes efLinkTypes);

		List<BOLinkTypes> MapEFToBO(
			List<LinkTypes> records);
	}
}

/*<Codenesium>
    <Hash>0675a88ce0097607777fc073c6cf5763</Hash>
</Codenesium>*/