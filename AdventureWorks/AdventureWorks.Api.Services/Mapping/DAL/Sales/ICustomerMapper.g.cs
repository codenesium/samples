using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCustomerMapper
	{
		Customer MapModelToEntity(
			int customerID,
			ApiCustomerServerRequestModel model);

		ApiCustomerServerResponseModel MapEntityToModel(
			Customer item);

		List<ApiCustomerServerResponseModel> MapEntityToModel(
			List<Customer> items);
	}
}

/*<Codenesium>
    <Hash>ad143cb22c03fa62bedaf942ceb86444</Hash>
</Codenesium>*/