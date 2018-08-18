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
    <Hash>5f2da3531bdafae1ac79293fbeeaee21</Hash>
</Codenesium>*/