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
    <Hash>1a79471373f4d4668c58f192ae761fa2</Hash>
</Codenesium>*/