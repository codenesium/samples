using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductProductPhotoMapper
	{
		DTOProductProductPhoto MapModelToDTO(
			int productID,
			ApiProductProductPhotoRequestModel model);

		ApiProductProductPhotoResponseModel MapDTOToModel(
			DTOProductProductPhoto dtoProductProductPhoto);

		List<ApiProductProductPhotoResponseModel> MapDTOToModel(
			List<DTOProductProductPhoto> dtos);
	}
}

/*<Codenesium>
    <Hash>606e8d1909baf77e1bcc74bfcdae6486</Hash>
</Codenesium>*/