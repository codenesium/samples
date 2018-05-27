using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLErrorLogMapper
	{
		DTOErrorLog MapModelToDTO(
			int errorLogID,
			ApiErrorLogRequestModel model);

		ApiErrorLogResponseModel MapDTOToModel(
			DTOErrorLog dtoErrorLog);

		List<ApiErrorLogResponseModel> MapDTOToModel(
			List<DTOErrorLog> dtos);
	}
}

/*<Codenesium>
    <Hash>f00536e6f20dbee908d1b5b77c7399ae</Hash>
</Codenesium>*/