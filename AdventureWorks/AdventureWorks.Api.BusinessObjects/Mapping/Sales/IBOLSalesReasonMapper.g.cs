using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesReasonMapper
	{
		DTOSalesReason MapModelToDTO(
			int salesReasonID,
			ApiSalesReasonRequestModel model);

		ApiSalesReasonResponseModel MapDTOToModel(
			DTOSalesReason dtoSalesReason);

		List<ApiSalesReasonResponseModel> MapDTOToModel(
			List<DTOSalesReason> dtos);
	}
}

/*<Codenesium>
    <Hash>08c64dc48fe4383de0646d0476644be4</Hash>
</Codenesium>*/