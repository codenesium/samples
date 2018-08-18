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
    <Hash>06e7046ebf372645bec65f850203e45e</Hash>
</Codenesium>*/