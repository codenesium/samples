using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPersonPhoneMapper
	{
		BOPersonPhone MapModelToBO(
			int businessEntityID,
			ApiPersonPhoneRequestModel model);

		ApiPersonPhoneResponseModel MapBOToModel(
			BOPersonPhone boPersonPhone);

		List<ApiPersonPhoneResponseModel> MapBOToModel(
			List<BOPersonPhone> items);
	}
}

/*<Codenesium>
    <Hash>8cce1117e6fe029838e32f6c6e8f2a32</Hash>
</Codenesium>*/