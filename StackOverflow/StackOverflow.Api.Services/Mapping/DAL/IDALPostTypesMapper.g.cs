using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostTypesMapper
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
    <Hash>d4ee13df5b762cb721dbb3de70e3b2e6</Hash>
</Codenesium>*/