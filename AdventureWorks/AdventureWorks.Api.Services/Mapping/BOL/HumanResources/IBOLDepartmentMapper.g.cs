using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLDepartmentMapper
	{
		BODepartment MapModelToBO(
			short departmentID,
			ApiDepartmentServerRequestModel model);

		ApiDepartmentServerResponseModel MapBOToModel(
			BODepartment boDepartment);

		List<ApiDepartmentServerResponseModel> MapBOToModel(
			List<BODepartment> items);
	}
}

/*<Codenesium>
    <Hash>53c639f0f419fe7d0fece3ee822c9524</Hash>
</Codenesium>*/