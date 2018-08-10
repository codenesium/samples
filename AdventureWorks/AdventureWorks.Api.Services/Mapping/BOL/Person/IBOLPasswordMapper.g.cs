using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPasswordMapper
	{
		BOPassword MapModelToBO(
			int businessEntityID,
			ApiPasswordRequestModel model);

		ApiPasswordResponseModel MapBOToModel(
			BOPassword boPassword);

		List<ApiPasswordResponseModel> MapBOToModel(
			List<BOPassword> items);
	}
}

/*<Codenesium>
    <Hash>95caf1e5500478dbb7b5df7f3793a967</Hash>
</Codenesium>*/