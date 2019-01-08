using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLColumnSameAsFKTableMapper
	{
		BOColumnSameAsFKTable MapModelToBO(
			int id,
			ApiColumnSameAsFKTableServerRequestModel model);

		ApiColumnSameAsFKTableServerResponseModel MapBOToModel(
			BOColumnSameAsFKTable boColumnSameAsFKTable);

		List<ApiColumnSameAsFKTableServerResponseModel> MapBOToModel(
			List<BOColumnSameAsFKTable> items);
	}
}

/*<Codenesium>
    <Hash>9b3b0328a4a8e624773ebf3f8fce6cf4</Hash>
</Codenesium>*/