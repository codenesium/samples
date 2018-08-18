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
			ApiEmployeeRequestModel model);

		ApiEmployeeResponseModel MapBOToModel(
			BOEmployee boEmployee);

		List<ApiEmployeeResponseModel> MapBOToModel(
			List<BOEmployee> items);
	}
}

/*<Codenesium>
    <Hash>535f0206855fe1522c1770ca01a49a13</Hash>
</Codenesium>*/