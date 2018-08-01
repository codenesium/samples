using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLPostHistoryMapper
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
    <Hash>ec006c0ac33b293bb599ea3f1a7ab4fe</Hash>
</Codenesium>*/