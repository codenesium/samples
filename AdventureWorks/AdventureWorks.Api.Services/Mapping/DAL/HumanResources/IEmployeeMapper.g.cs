using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALEmployeeMapper
	{
		Employee MapModelToBO(
			int businessEntityID,
			ApiEmployeeServerRequestModel model);

		ApiEmployeeServerResponseModel MapBOToModel(
			Employee item);

		List<ApiEmployeeServerResponseModel> MapBOToModel(
			List<Employee> items);
	}
}

/*<Codenesium>
    <Hash>ac0971afbb8d74a3a8a6acac386d4442</Hash>
</Codenesium>*/