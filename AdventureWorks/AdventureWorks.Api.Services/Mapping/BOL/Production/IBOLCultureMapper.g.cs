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
			ApiCultureRequestModel model);

		ApiCultureResponseModel MapBOToModel(
			BOCulture boCulture);

		List<ApiCultureResponseModel> MapBOToModel(
			List<BOCulture> items);
	}
}

/*<Codenesium>
    <Hash>1f0425573fe816a98b283fb055e6fb75</Hash>
</Codenesium>*/