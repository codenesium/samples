using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>27b864cf21d49c8bc326b69412ce1a36</Hash>
</Codenesium>*/