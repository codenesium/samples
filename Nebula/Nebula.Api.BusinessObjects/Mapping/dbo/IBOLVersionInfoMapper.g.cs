using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLVersionInfoMapper
	{
		DTOVersionInfo MapModelToDTO(
			long version,
			ApiVersionInfoRequestModel model);

		ApiVersionInfoResponseModel MapDTOToModel(
			DTOVersionInfo dtoVersionInfo);

		List<ApiVersionInfoResponseModel> MapDTOToModel(
			List<DTOVersionInfo> dtos);
	}
}

/*<Codenesium>
    <Hash>3accb0b51c6b1fcef1f5778f2819d598</Hash>
</Codenesium>*/