using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALPostHistoryMapper
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
    <Hash>0f05c53dc84bae9c65ea66ec93f9b3cf</Hash>
</Codenesium>*/