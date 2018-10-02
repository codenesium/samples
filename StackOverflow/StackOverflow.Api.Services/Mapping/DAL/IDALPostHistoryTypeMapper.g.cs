using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostHistoryTypeMapper
	{
		PostHistoryType MapBOToEF(
			BOPostHistoryType bo);

		BOPostHistoryType MapEFToBO(
			PostHistoryType efPostHistoryType);

		List<BOPostHistoryType> MapEFToBO(
			List<PostHistoryType> records);
	}
}

/*<Codenesium>
    <Hash>9a7b070a1a7ea0696c99216b6ed52781</Hash>
</Codenesium>*/