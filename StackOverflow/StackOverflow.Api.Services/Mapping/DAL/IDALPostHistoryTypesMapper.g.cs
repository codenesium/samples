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
    <Hash>ac9313b8d3d5ae00e2b77704c5cfc1a2</Hash>
</Codenesium>*/