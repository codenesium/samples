using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLSchemaBPersonMapper
	{
		BOSchemaBPerson MapModelToBO(
			int id,
			ApiSchemaBPersonRequestModel model);

		ApiSchemaBPersonResponseModel MapBOToModel(
			BOSchemaBPerson boSchemaBPerson);

		List<ApiSchemaBPersonResponseModel> MapBOToModel(
			List<BOSchemaBPerson> items);
	}
}

/*<Codenesium>
    <Hash>bc00cd7fd2b82843266ebf45853b2049</Hash>
</Codenesium>*/