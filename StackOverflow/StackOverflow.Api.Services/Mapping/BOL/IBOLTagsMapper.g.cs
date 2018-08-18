using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLTagsMapper
	{
		BOTags MapModelToBO(
			int id,
			ApiTagsRequestModel model);

		ApiTagsResponseModel MapBOToModel(
			BOTags boTags);

		List<ApiTagsResponseModel> MapBOToModel(
			List<BOTags> items);
	}
}

/*<Codenesium>
    <Hash>a5ba64b345670c4c48ba954dfe9bc755</Hash>
</Codenesium>*/