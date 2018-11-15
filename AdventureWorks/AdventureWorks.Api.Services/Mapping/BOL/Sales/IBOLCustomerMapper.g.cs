using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCustomerMapper
	{
		BOCustomer MapModelToBO(
			int customerID,
			ApiCustomerServerRequestModel model);

		ApiCustomerServerResponseModel MapBOToModel(
			BOCustomer boCustomer);

		List<ApiCustomerServerResponseModel> MapBOToModel(
			List<BOCustomer> items);
	}
}

/*<Codenesium>
    <Hash>a1e5ea5877858d43940579e410bcfd9c</Hash>
</Codenesium>*/