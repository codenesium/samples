using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCultureMapper
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
    <Hash>90d357b6604ba8a78beb250b29e57aeb</Hash>
</Codenesium>*/