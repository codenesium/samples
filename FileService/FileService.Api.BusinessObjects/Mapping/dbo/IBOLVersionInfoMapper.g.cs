using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
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
    <Hash>af06d8f616f9083cd42136e108a8c661</Hash>
</Codenesium>*/