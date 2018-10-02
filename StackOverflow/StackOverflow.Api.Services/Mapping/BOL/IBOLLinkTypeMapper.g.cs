using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLLinkTypeMapper
	{
		BOLinkType MapModelToBO(
			int id,
			ApiLinkTypeRequestModel model);

		ApiLinkTypeResponseModel MapBOToModel(
			BOLinkType boLinkType);

		List<ApiLinkTypeResponseModel> MapBOToModel(
			List<BOLinkType> items);
	}
}

/*<Codenesium>
    <Hash>9c90c97a083d168230b9f58ac761bab2</Hash>
</Codenesium>*/