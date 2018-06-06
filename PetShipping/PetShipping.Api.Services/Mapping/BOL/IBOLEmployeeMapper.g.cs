using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLEmployeeMapper
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
    <Hash>3dc1303cfe8b5f9e9e2e569621be4cb9</Hash>
</Codenesium>*/