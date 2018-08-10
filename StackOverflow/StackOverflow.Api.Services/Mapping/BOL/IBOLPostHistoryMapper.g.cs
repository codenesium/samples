using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostHistoryMapper
	{
		BOPostHistory MapModelToBO(
			int id,
			ApiPostHistoryRequestModel model);

		ApiPostHistoryResponseModel MapBOToModel(
			BOPostHistory boPostHistory);

		List<ApiPostHistoryResponseModel> MapBOToModel(
			List<BOPostHistory> items);
	}
}

/*<Codenesium>
    <Hash>32f21083b37071b677b72765f2611305</Hash>
</Codenesium>*/