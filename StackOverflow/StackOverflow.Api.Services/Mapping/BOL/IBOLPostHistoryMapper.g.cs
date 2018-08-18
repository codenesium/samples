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
    <Hash>f725937ffb18f42a9969ff2863687232</Hash>
</Codenesium>*/