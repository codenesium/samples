using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALBadgeMapper
	{
		Badge MapModelToEntity(
			int id,
			ApiBadgeServerRequestModel model);

		ApiBadgeServerResponseModel MapEntityToModel(
			Badge item);

		List<ApiBadgeServerResponseModel> MapEntityToModel(
			List<Badge> items);
	}
}

/*<Codenesium>
    <Hash>d325f06b2b4888eedc5ac49fd3d47101</Hash>
</Codenesium>*/