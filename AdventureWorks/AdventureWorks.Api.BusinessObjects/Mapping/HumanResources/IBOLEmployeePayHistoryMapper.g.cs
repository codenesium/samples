using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLEmployeePayHistoryMapper
	{
		DTOEmployeePayHistory MapModelToDTO(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model);

		ApiEmployeePayHistoryResponseModel MapDTOToModel(
			DTOEmployeePayHistory dtoEmployeePayHistory);

		List<ApiEmployeePayHistoryResponseModel> MapDTOToModel(
			List<DTOEmployeePayHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>f4d36671f9383c88e6f6e1b4960b32e2</Hash>
</Codenesium>*/