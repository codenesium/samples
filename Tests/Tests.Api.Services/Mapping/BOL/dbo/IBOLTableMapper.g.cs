using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLTableMapper
	{
		BOTable MapModelToBO(
			int id,
			ApiTableRequestModel model);

		ApiTableResponseModel MapBOToModel(
			BOTable boTable);

		List<ApiTableResponseModel> MapBOToModel(
			List<BOTable> items);
	}
}

/*<Codenesium>
    <Hash>64ebaaab57b9a49219e3bdd687da36b5</Hash>
</Codenesium>*/