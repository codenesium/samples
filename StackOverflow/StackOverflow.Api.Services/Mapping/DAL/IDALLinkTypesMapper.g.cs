using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALLinkTypesMapper
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
    <Hash>df8239b1b0ff2ad2916e1cd465b9beb9</Hash>
</Codenesium>*/