using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLLinkStatusMapper
	{
		DTOLinkStatus MapModelToDTO(
			int id,
			ApiLinkStatusRequestModel model);

		ApiLinkStatusResponseModel MapDTOToModel(
			DTOLinkStatus dtoLinkStatus);

		List<ApiLinkStatusResponseModel> MapDTOToModel(
			List<DTOLinkStatus> dtos);
	}
}

/*<Codenesium>
    <Hash>941acc79e424be48ce650957b25a4133</Hash>
</Codenesium>*/