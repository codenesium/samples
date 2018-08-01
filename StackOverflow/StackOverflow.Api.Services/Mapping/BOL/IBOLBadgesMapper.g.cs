using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLBadgesMapper
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
    <Hash>bb0f6712a714b3388b320ce2cf306c88</Hash>
</Codenesium>*/