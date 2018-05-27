using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductPhotoMapper
	{
		DTOProductPhoto MapModelToDTO(
			int productPhotoID,
			ApiProductPhotoRequestModel model);

		ApiProductPhotoResponseModel MapDTOToModel(
			DTOProductPhoto dtoProductPhoto);

		List<ApiProductPhotoResponseModel> MapDTOToModel(
			List<DTOProductPhoto> dtos);
	}
}

/*<Codenesium>
    <Hash>2d477c701d28b3051b2ad52fefa1d4b8</Hash>
</Codenesium>*/