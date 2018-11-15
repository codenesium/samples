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
			ApiPostHistoryServerRequestModel model);

		ApiPostHistoryServerResponseModel MapBOToModel(
			BOPostHistory boPostHistory);

		List<ApiPostHistoryServerResponseModel> MapBOToModel(
			List<BOPostHistory> items);
	}
}

/*<Codenesium>
    <Hash>108e49aa1fb85b1f77924fce32c0932c</Hash>
</Codenesium>*/