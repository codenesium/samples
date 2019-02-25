using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPersonMapper
	{
		Person MapModelToEntity(
			int businessEntityID,
			ApiPersonServerRequestModel model);

		ApiPersonServerResponseModel MapEntityToModel(
			Person item);

		List<ApiPersonServerResponseModel> MapEntityToModel(
			List<Person> items);
	}
}

/*<Codenesium>
    <Hash>8e3619c3493832f5af7b44d4c1d1cdf0</Hash>
</Codenesium>*/