using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostLinksMapper
	{
		BOPostLinks MapModelToBO(
			int id,
			ApiPostLinksRequestModel model);

		ApiPostLinksResponseModel MapBOToModel(
			BOPostLinks boPostLinks);

		List<ApiPostLinksResponseModel> MapBOToModel(
			List<BOPostLinks> items);
	}
}

/*<Codenesium>
    <Hash>b8a5c52bbe32ef29f9f96f9824b10275</Hash>
</Codenesium>*/