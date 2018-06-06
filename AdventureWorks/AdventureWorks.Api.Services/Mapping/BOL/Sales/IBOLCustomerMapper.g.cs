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
			List<BOCustomer> items);
	}
}

/*<Codenesium>
    <Hash>4feeb4e0bbb1f013a01b2aaf0b088d41</Hash>
</Codenesium>*/