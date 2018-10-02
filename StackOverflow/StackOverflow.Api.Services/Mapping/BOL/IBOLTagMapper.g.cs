using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLTagMapper
	{
		BOTag MapModelToBO(
			int id,
			ApiTagRequestModel model);

		ApiTagResponseModel MapBOToModel(
			BOTag boTag);

		List<ApiTagResponseModel> MapBOToModel(
			List<BOTag> items);
	}
}

/*<Codenesium>
    <Hash>79fc29dfe4d079dab05840dda6535bc7</Hash>
</Codenesium>*/