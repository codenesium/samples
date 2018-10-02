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
			ApiPostRequestModel model);

		ApiPostResponseModel MapBOToModel(
			BOPost boPost);

		List<ApiPostResponseModel> MapBOToModel(
			List<BOPost> items);
	}
}

/*<Codenesium>
    <Hash>216053bde7b712536643c3648966995f</Hash>
</Codenesium>*/