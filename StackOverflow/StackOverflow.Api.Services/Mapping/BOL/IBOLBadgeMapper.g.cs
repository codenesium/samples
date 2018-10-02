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
			ApiBadgeRequestModel model);

		ApiBadgeResponseModel MapBOToModel(
			BOBadge boBadge);

		List<ApiBadgeResponseModel> MapBOToModel(
			List<BOBadge> items);
	}
}

/*<Codenesium>
    <Hash>06fa0303ac9b1babc722d3d0873821a2</Hash>
</Codenesium>*/