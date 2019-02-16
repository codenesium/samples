using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDepartmentMapper
	{
		Department MapModelToBO(
			short departmentID,
			ApiDepartmentServerRequestModel model);

		ApiDepartmentServerResponseModel MapBOToModel(
			Department item);

		List<ApiDepartmentServerResponseModel> MapBOToModel(
			List<Department> items);
	}
}

/*<Codenesium>
    <Hash>c7430b1c1b56afcd30702d7240470c5c</Hash>
</Codenesium>*/