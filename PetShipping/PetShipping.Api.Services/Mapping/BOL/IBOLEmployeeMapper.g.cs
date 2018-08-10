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
    <Hash>76336e693204d1d3c16967500dcb06a2</Hash>
</Codenesium>*/