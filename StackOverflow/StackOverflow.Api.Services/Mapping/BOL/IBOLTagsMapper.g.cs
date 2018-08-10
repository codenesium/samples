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
    <Hash>dfe34dd16db29f0f5900c802616dba27</Hash>
</Codenesium>*/