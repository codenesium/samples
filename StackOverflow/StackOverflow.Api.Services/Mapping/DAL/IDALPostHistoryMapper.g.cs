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
    <Hash>b2368118d6f9ce1929689462d7f0d1f3</Hash>
</Codenesium>*/