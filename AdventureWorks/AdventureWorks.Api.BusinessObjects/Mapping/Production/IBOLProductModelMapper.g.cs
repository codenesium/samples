using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductModelMapper
	{
		DTOProductModel MapModelToDTO(
			int productModelID,
			ApiProductModelRequestModel model);

		ApiProductModelResponseModel MapDTOToModel(
			DTOProductModel dtoProductModel);

		List<ApiProductModelResponseModel> MapDTOToModel(
			List<DTOProductModel> dtos);
	}
}

/*<Codenesium>
    <Hash>33e0bbb1816dfde2b630d4c001c6af79</Hash>
</Codenesium>*/