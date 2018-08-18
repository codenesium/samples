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
    <Hash>2a940113107f11c343b5dc0e99b30885</Hash>
</Codenesium>*/