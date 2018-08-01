using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALPostHistoryTypesMapper
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
    <Hash>30c4276446b6510e55423148467e4cd9</Hash>
</Codenesium>*/