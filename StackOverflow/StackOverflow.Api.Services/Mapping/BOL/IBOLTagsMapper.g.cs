using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLTagsMapper
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
    <Hash>2bef6ae08136d61efbe5f3a22c9342a3</Hash>
</Codenesium>*/