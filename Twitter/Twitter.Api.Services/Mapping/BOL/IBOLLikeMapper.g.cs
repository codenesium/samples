using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLLikeMapper
	{
		BOLike MapModelToBO(
			int likeId,
			ApiLikeRequestModel model);

		ApiLikeResponseModel MapBOToModel(
			BOLike boLike);

		List<ApiLikeResponseModel> MapBOToModel(
			List<BOLike> items);
	}
}

/*<Codenesium>
    <Hash>a8a162842dc0eceae8ed6ed4cb5f40ba</Hash>
</Codenesium>*/