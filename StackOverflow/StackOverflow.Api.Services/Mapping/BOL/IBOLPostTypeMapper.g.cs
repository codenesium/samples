using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostTypeMapper
	{
		BOPostType MapModelToBO(
			int id,
			ApiPostTypeRequestModel model);

		ApiPostTypeResponseModel MapBOToModel(
			BOPostType boPostType);

		List<ApiPostTypeResponseModel> MapBOToModel(
			List<BOPostType> items);
	}
}

/*<Codenesium>
    <Hash>945ad873db98386d2a469db59d0fb148</Hash>
</Codenesium>*/