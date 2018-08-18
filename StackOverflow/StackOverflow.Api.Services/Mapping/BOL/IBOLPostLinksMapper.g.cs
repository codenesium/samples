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
    <Hash>ef7db85d06ac7cc6685e314e966b31db</Hash>
</Codenesium>*/