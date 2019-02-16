using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALColumnSameAsFKTableMapper
	{
		ColumnSameAsFKTable MapModelToEntity(
			int id,
			ApiColumnSameAsFKTableServerRequestModel model);

		ApiColumnSameAsFKTableServerResponseModel MapEntityToModel(
			ColumnSameAsFKTable item);

		List<ApiColumnSameAsFKTableServerResponseModel> MapEntityToModel(
			List<ColumnSameAsFKTable> items);
	}
}

/*<Codenesium>
    <Hash>42fdab11960a95bfaecee1f3ba040f1a</Hash>
</Codenesium>*/