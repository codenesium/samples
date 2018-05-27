using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductCategoryMapper
	{
		DTOProductCategory MapModelToDTO(
			int productCategoryID,
			ApiProductCategoryRequestModel model);

		ApiProductCategoryResponseModel MapDTOToModel(
			DTOProductCategory dtoProductCategory);

		List<ApiProductCategoryResponseModel> MapDTOToModel(
			List<DTOProductCategory> dtos);
	}
}

/*<Codenesium>
    <Hash>7d0b2fa4faa65b8bf7fa5d57fb89d288</Hash>
</Codenesium>*/