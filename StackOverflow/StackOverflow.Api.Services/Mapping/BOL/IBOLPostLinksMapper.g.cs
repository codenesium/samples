using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLPostLinksMapper
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
    <Hash>f764af4893b9f4afd23c52c3f6ad1b3a</Hash>
</Codenesium>*/