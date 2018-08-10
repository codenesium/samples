using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostHistoryTypesMapper
	{
		BOPostHistoryTypes MapModelToBO(
			int id,
			ApiPostHistoryTypesRequestModel model);

		ApiPostHistoryTypesResponseModel MapBOToModel(
			BOPostHistoryTypes boPostHistoryTypes);

		List<ApiPostHistoryTypesResponseModel> MapBOToModel(
			List<BOPostHistoryTypes> items);
	}
}

/*<Codenesium>
    <Hash>339fa28ad9db6153ca07a6eed1b20c85</Hash>
</Codenesium>*/