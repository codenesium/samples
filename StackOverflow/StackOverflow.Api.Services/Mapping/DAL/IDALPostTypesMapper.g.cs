using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALPostTypesMapper
	{
		PostTypes MapBOToEF(
			BOPostTypes bo);

		BOPostTypes MapEFToBO(
			PostTypes efPostTypes);

		List<BOPostTypes> MapEFToBO(
			List<PostTypes> records);
	}
}

/*<Codenesium>
    <Hash>ba1b23ef7e8e73c1d5ae9815c1e9b5fd</Hash>
</Codenesium>*/