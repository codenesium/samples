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
    <Hash>884be1db64e0823584be55a235c3c20d</Hash>
</Codenesium>*/