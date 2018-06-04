using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCustomerMapper
	{
		BOCustomer MapModelToBO(
			int customerID,
			ApiCustomerRequestModel model);

		ApiCustomerResponseModel MapBOToModel(
			BOCustomer boCustomer);

		List<ApiCustomerResponseModel> MapBOToModel(
			List<BOCustomer> bos);
	}
}

/*<Codenesium>
    <Hash>fa9aa45d5f88f5bbd5b90a211f0456df</Hash>
</Codenesium>*/