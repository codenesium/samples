using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLEmployeeMapper
	{
		DTOEmployee MapModelToDTO(
			int businessEntityID,
			ApiEmployeeRequestModel model);

		ApiEmployeeResponseModel MapDTOToModel(
			DTOEmployee dtoEmployee);

		List<ApiEmployeeResponseModel> MapDTOToModel(
			List<DTOEmployee> dtos);
	}
}

/*<Codenesium>
    <Hash>a689ff1ccd4ac5c56b47c9231ca720cc</Hash>
</Codenesium>*/