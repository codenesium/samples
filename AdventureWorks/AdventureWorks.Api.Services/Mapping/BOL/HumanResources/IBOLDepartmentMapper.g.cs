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
			ApiDepartmentRequestModel model);

		ApiDepartmentResponseModel MapBOToModel(
			BODepartment boDepartment);

		List<ApiDepartmentResponseModel> MapBOToModel(
			List<BODepartment> items);
	}
}

/*<Codenesium>
    <Hash>6b9f6ef788226509bf81bb9cb61cd101</Hash>
</Codenesium>*/