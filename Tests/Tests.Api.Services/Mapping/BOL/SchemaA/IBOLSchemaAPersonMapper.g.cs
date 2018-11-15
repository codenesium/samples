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
			ApiSchemaAPersonServerRequestModel model);

		ApiSchemaAPersonServerResponseModel MapBOToModel(
			BOSchemaAPerson boSchemaAPerson);

		List<ApiSchemaAPersonServerResponseModel> MapBOToModel(
			List<BOSchemaAPerson> items);
	}
}

/*<Codenesium>
    <Hash>be3822804d122db1ca647950d4a5962f</Hash>
</Codenesium>*/