using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostHistoryTypeMapper
	{
		BOPostHistoryType MapModelToBO(
			int id,
			ApiPostHistoryTypeServerRequestModel model);

		ApiPostHistoryTypeServerResponseModel MapBOToModel(
			BOPostHistoryType boPostHistoryType);

		List<ApiPostHistoryTypeServerResponseModel> MapBOToModel(
			List<BOPostHistoryType> items);
	}
}

/*<Codenesium>
    <Hash>b5c31f139916517a5d7681bb0552b763</Hash>
</Codenesium>*/