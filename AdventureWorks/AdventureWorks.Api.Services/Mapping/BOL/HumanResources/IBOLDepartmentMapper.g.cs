using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLDepartmentMapper
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
    <Hash>12140ea7a3d927e2734b82356176827f</Hash>
</Codenesium>*/