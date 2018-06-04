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
			List<BODepartment> bos);
	}
}

/*<Codenesium>
    <Hash>0fad16fcf53304aca043575dca6fa429</Hash>
</Codenesium>*/