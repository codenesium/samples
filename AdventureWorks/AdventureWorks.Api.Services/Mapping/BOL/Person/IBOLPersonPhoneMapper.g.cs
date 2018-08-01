using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPersonPhoneMapper
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
    <Hash>84513575179293c16527c15f9689299d</Hash>
</Codenesium>*/