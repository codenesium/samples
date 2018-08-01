using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLSchemaAPersonMapper
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
    <Hash>0dce509dbc4102d731dc62263aa328b6</Hash>
</Codenesium>*/