using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLSchemaAPersonMapper
	{
		BOSchemaAPerson MapModelToBO(
			int id,
			ApiSchemaAPersonRequestModel model);

		ApiSchemaAPersonResponseModel MapBOToModel(
			BOSchemaAPerson boSchemaAPerson);

		List<ApiSchemaAPersonResponseModel> MapBOToModel(
			List<BOSchemaAPerson> items);
	}
}

/*<Codenesium>
    <Hash>fc22b90d05e4d138196e07e9c8195f7d</Hash>
</Codenesium>*/