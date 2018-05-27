using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLDepartmentMapper
	{
		DTODepartment MapModelToDTO(
			short departmentID,
			ApiDepartmentRequestModel model);

		ApiDepartmentResponseModel MapDTOToModel(
			DTODepartment dtoDepartment);

		List<ApiDepartmentResponseModel> MapDTOToModel(
			List<DTODepartment> dtos);
	}
}

/*<Codenesium>
    <Hash>f63bba434bd7082d61a99d21544e6513</Hash>
</Codenesium>*/