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
			ApiColumnSameAsFKTableRequestModel model);

		ApiColumnSameAsFKTableResponseModel MapBOToModel(
			BOColumnSameAsFKTable boColumnSameAsFKTable);

		List<ApiColumnSameAsFKTableResponseModel> MapBOToModel(
			List<BOColumnSameAsFKTable> items);
	}
}

/*<Codenesium>
    <Hash>98cf5ad4c00e00dd29ce682ce472fe9d</Hash>
</Codenesium>*/