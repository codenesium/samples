using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLEmployeeMapper
	{
		BOEmployee MapModelToBO(
			int id,
			ApiEmployeeServerRequestModel model);

		ApiEmployeeServerResponseModel MapBOToModel(
			BOEmployee boEmployee);

		List<ApiEmployeeServerResponseModel> MapBOToModel(
			List<BOEmployee> items);
	}
}

/*<Codenesium>
    <Hash>873b8991acf4576d297bd4d11c890a69</Hash>
</Codenesium>*/