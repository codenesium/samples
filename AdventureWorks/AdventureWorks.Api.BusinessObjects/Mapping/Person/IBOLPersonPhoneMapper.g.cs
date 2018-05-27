using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPersonPhoneMapper
	{
		DTOPersonPhone MapModelToDTO(
			int businessEntityID,
			ApiPersonPhoneRequestModel model);

		ApiPersonPhoneResponseModel MapDTOToModel(
			DTOPersonPhone dtoPersonPhone);

		List<ApiPersonPhoneResponseModel> MapDTOToModel(
			List<DTOPersonPhone> dtos);
	}
}

/*<Codenesium>
    <Hash>b4c3596438d9dd79a28eb464240ea7ab</Hash>
</Codenesium>*/