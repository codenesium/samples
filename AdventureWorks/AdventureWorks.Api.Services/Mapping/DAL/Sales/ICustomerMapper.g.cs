using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCustomerMapper
	{
		Customer MapModelToBO(
			int customerID,
			ApiCustomerServerRequestModel model);

		ApiCustomerServerResponseModel MapBOToModel(
			Customer item);

		List<ApiCustomerServerResponseModel> MapBOToModel(
			List<Customer> items);
	}
}

/*<Codenesium>
    <Hash>78ad612567c86a6b847350cea3fe2eb5</Hash>
</Codenesium>*/