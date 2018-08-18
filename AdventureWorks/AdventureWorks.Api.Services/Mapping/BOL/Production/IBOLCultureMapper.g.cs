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
    <Hash>2fd9308d52661c1b273c3c197a056f70</Hash>
</Codenesium>*/