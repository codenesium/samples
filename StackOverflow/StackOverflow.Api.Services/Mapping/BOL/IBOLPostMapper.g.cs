using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostMapper
	{
		BOPost MapModelToBO(
			int id,
			ApiPostServerRequestModel model);

		ApiPostServerResponseModel MapBOToModel(
			BOPost boPost);

		List<ApiPostServerResponseModel> MapBOToModel(
			List<BOPost> items);
	}
}

/*<Codenesium>
    <Hash>79e248a52a806823212c2421821ef0f4</Hash>
</Codenesium>*/