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
    <Hash>41029ef16ff02ce73935b3b5675c364d</Hash>
</Codenesium>*/