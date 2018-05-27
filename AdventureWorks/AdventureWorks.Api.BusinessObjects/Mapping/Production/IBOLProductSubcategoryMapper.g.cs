using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductSubcategoryMapper
	{
		DTOProductSubcategory MapModelToDTO(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model);

		ApiProductSubcategoryResponseModel MapDTOToModel(
			DTOProductSubcategory dtoProductSubcategory);

		List<ApiProductSubcategoryResponseModel> MapDTOToModel(
			List<DTOProductSubcategory> dtos);
	}
}

/*<Codenesium>
    <Hash>2fb33a59c071b7e182f7427280f059b5</Hash>
</Codenesium>*/