using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLBadgesMapper
	{
		BOBadges MapModelToBO(
			int id,
			ApiBadgesRequestModel model);

		ApiBadgesResponseModel MapBOToModel(
			BOBadges boBadges);

		List<ApiBadgesResponseModel> MapBOToModel(
			List<BOBadges> items);
	}
}

/*<Codenesium>
    <Hash>96129a4e485b424f49571483b3b3f16a</Hash>
</Codenesium>*/