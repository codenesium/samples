using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLCommentMapper
	{
		BOComment MapModelToBO(
			int id,
			ApiCommentRequestModel model);

		ApiCommentResponseModel MapBOToModel(
			BOComment boComment);

		List<ApiCommentResponseModel> MapBOToModel(
			List<BOComment> items);
	}
}

/*<Codenesium>
    <Hash>fe454bbfba3ed4d3ca6a5cace437f30b</Hash>
</Codenesium>*/