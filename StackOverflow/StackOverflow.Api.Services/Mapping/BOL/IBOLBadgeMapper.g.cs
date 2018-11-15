using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLBadgeMapper
	{
		BOBadge MapModelToBO(
			int id,
			ApiBadgeServerRequestModel model);

		ApiBadgeServerResponseModel MapBOToModel(
			BOBadge boBadge);

		List<ApiBadgeServerResponseModel> MapBOToModel(
			List<BOBadge> items);
	}
}

/*<Codenesium>
    <Hash>dd86c9b35f1686c9d4f5bc990ca7cee4</Hash>
</Codenesium>*/