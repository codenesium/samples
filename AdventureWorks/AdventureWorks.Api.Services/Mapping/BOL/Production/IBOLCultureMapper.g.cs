using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCultureMapper
	{
		BOCulture MapModelToBO(
			string cultureID,
			ApiCultureServerRequestModel model);

		ApiCultureServerResponseModel MapBOToModel(
			BOCulture boCulture);

		List<ApiCultureServerResponseModel> MapBOToModel(
			List<BOCulture> items);
	}
}

/*<Codenesium>
    <Hash>34380cf0a7e0f09d37a6554b9fac23e5</Hash>
</Codenesium>*/