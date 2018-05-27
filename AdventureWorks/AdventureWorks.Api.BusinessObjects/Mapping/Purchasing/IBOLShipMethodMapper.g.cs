using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLShipMethodMapper
	{
		DTOShipMethod MapModelToDTO(
			int shipMethodID,
			ApiShipMethodRequestModel model);

		ApiShipMethodResponseModel MapDTOToModel(
			DTOShipMethod dtoShipMethod);

		List<ApiShipMethodResponseModel> MapDTOToModel(
			List<DTOShipMethod> dtos);
	}
}

/*<Codenesium>
    <Hash>2249f5de44452f3cdcf6ce83aae092fa</Hash>
</Codenesium>*/