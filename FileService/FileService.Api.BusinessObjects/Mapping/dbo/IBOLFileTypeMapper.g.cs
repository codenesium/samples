using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOLFileTypeMapper
	{
		DTOFileType MapModelToDTO(
			int id,
			ApiFileTypeRequestModel model);

		ApiFileTypeResponseModel MapDTOToModel(
			DTOFileType dtoFileType);

		List<ApiFileTypeResponseModel> MapDTOToModel(
			List<DTOFileType> dtos);
	}
}

/*<Codenesium>
    <Hash>580d1ee4a7cd81e0163354ba469dcd16</Hash>
</Codenesium>*/