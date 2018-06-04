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
			List<BOEmployee> bos);
	}
}

/*<Codenesium>
    <Hash>c73b669f6c03aca4b956d67fe2d83512</Hash>
</Codenesium>*/