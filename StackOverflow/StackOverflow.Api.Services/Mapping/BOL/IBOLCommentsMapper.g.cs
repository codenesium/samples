using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLCommentsMapper
	{
		BOComments MapModelToBO(
			int id,
			ApiCommentsRequestModel model);

		ApiCommentsResponseModel MapBOToModel(
			BOComments boComments);

		List<ApiCommentsResponseModel> MapBOToModel(
			List<BOComments> items);
	}
}

/*<Codenesium>
    <Hash>cb94ddc5a1ce42a56fc2a8a37203a294</Hash>
</Codenesium>*/