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
    <Hash>274675c73ff162f6bc12b2225dadf199</Hash>
</Codenesium>*/