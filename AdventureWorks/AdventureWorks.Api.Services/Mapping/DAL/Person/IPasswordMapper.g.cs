using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPasswordMapper
	{
		Password MapModelToEntity(
			int businessEntityID,
			ApiPasswordServerRequestModel model);

		ApiPasswordServerResponseModel MapEntityToModel(
			Password item);

		List<ApiPasswordServerResponseModel> MapEntityToModel(
			List<Password> items);
	}
}

/*<Codenesium>
    <Hash>04e82a8d26e7871d42ff9e8e67f5482b</Hash>
</Codenesium>*/