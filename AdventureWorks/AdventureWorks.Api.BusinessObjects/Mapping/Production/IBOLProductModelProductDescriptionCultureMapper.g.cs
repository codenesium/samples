using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductModelProductDescriptionCultureMapper
	{
		DTOProductModelProductDescriptionCulture MapModelToDTO(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model);

		ApiProductModelProductDescriptionCultureResponseModel MapDTOToModel(
			DTOProductModelProductDescriptionCulture dtoProductModelProductDescriptionCulture);

		List<ApiProductModelProductDescriptionCultureResponseModel> MapDTOToModel(
			List<DTOProductModelProductDescriptionCulture> dtos);
	}
}

/*<Codenesium>
    <Hash>3855ba833239ce313692a732e20e6d13</Hash>
</Codenesium>*/