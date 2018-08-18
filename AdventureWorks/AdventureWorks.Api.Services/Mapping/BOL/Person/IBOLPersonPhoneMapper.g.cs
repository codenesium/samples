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
    <Hash>c05270d3a08e6e81f75527b59d26bdb6</Hash>
</Codenesium>*/