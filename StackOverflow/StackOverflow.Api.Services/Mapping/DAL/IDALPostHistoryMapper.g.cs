using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostHistoryMapper
	{
		PostHistory MapBOToEF(
			BOPostHistory bo);

		BOPostHistory MapEFToBO(
			PostHistory efPostHistory);

		List<BOPostHistory> MapEFToBO(
			List<PostHistory> records);
	}
}

/*<Codenesium>
    <Hash>14d7504bef48d31eb56c5ba37d36f8f3</Hash>
</Codenesium>*/