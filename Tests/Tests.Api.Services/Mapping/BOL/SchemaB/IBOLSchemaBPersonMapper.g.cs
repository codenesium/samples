using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLSchemaBPersonMapper
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
    <Hash>31ad61d215f0eacf88db9dd89e48bb0f</Hash>
</Codenesium>*/