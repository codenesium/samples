using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLEmployeeDepartmentHistoryMapper
	{
		DTOEmployeeDepartmentHistory MapModelToDTO(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model);

		ApiEmployeeDepartmentHistoryResponseModel MapDTOToModel(
			DTOEmployeeDepartmentHistory dtoEmployeeDepartmentHistory);

		List<ApiEmployeeDepartmentHistoryResponseModel> MapDTOToModel(
			List<DTOEmployeeDepartmentHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>6c19936acc0369ba8e758358d1f6ccf2</Hash>
</Codenesium>*/