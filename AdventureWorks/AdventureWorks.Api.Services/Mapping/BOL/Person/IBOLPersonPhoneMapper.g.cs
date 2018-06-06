using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>00f1090b567131d0ec7e64b69276550b</Hash>
</Codenesium>*/