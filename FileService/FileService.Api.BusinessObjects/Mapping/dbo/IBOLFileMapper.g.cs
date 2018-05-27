using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOLFileMapper
	{
		DTOFile MapModelToDTO(
			int id,
			ApiFileRequestModel model);

		ApiFileResponseModel MapDTOToModel(
			DTOFile dtoFile);

		List<ApiFileResponseModel> MapDTOToModel(
			List<DTOFile> dtos);
	}
}

/*<Codenesium>
    <Hash>5480dd4dcff756b283955eb8b75c99c5</Hash>
</Codenesium>*/