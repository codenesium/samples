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
			ApiPostHistoryTypeRequestModel model);

		ApiPostHistoryTypeResponseModel MapBOToModel(
			BOPostHistoryType boPostHistoryType);

		List<ApiPostHistoryTypeResponseModel> MapBOToModel(
			List<BOPostHistoryType> items);
	}
}

/*<Codenesium>
    <Hash>460f04428ccbfa91179427e76defb2e7</Hash>
</Codenesium>*/