using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDepartmentMapper
	{
		Department MapModelToEntity(
			short departmentID,
			ApiDepartmentServerRequestModel model);

		ApiDepartmentServerResponseModel MapEntityToModel(
			Department item);

		List<ApiDepartmentServerResponseModel> MapEntityToModel(
			List<Department> items);
	}
}

/*<Codenesium>
    <Hash>b6af90d0b5f18cb1434dc2a4739b6926</Hash>
</Codenesium>*/