using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLPostHistoryTypesMapper
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
    <Hash>8611ca160b347a19b5348c79c793c41b</Hash>
</Codenesium>*/