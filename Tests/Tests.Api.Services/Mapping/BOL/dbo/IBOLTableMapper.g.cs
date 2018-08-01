using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLTableMapper
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
    <Hash>0e3efbe7cb9ed72317f432211fe754fc</Hash>
</Codenesium>*/