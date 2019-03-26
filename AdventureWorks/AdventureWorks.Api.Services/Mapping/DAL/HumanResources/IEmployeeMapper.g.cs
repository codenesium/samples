using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALEmployeeMapper
	{
		Employee MapModelToEntity(
			int businessEntityID,
			ApiEmployeeServerRequestModel model);

		ApiEmployeeServerResponseModel MapEntityToModel(
			Employee item);

		List<ApiEmployeeServerResponseModel> MapEntityToModel(
			List<Employee> items);
	}
}

/*<Codenesium>
    <Hash>a7cb33c6425e602494fab76adc0e467f</Hash>
</Codenesium>*/