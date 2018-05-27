using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductVendorMapper
	{
		DTOProductVendor MapModelToDTO(
			int productID,
			ApiProductVendorRequestModel model);

		ApiProductVendorResponseModel MapDTOToModel(
			DTOProductVendor dtoProductVendor);

		List<ApiProductVendorResponseModel> MapDTOToModel(
			List<DTOProductVendor> dtos);
	}
}

/*<Codenesium>
    <Hash>0963c7969ca1e2bcf419a2a70a913d9d</Hash>
</Codenesium>*/