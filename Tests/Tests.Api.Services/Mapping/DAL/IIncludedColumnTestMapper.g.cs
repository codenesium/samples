using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALIncludedColumnTestMapper
	{
		IncludedColumnTest MapModelToEntity(
			int id,
			ApiIncludedColumnTestServerRequestModel model);

		ApiIncludedColumnTestServerResponseModel MapEntityToModel(
			IncludedColumnTest item);

		List<ApiIncludedColumnTestServerResponseModel> MapEntityToModel(
			List<IncludedColumnTest> items);
	}
}

/*<Codenesium>
    <Hash>c14c3dea60ad4e68027a22b7ce04fba7</Hash>
</Codenesium>*/