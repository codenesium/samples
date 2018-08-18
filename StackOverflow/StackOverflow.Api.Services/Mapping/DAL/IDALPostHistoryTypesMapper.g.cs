using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostHistoryTypesMapper
	{
		PostHistoryTypes MapBOToEF(
			BOPostHistoryTypes bo);

		BOPostHistoryTypes MapEFToBO(
			PostHistoryTypes efPostHistoryTypes);

		List<BOPostHistoryTypes> MapEFToBO(
			List<PostHistoryTypes> records);
	}
}

/*<Codenesium>
    <Hash>f5a9f68c983ba621719d2c08cc11408a</Hash>
</Codenesium>*/