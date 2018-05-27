using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLVendorMapper
	{
		DTOVendor MapModelToDTO(
			int businessEntityID,
			ApiVendorRequestModel model);

		ApiVendorResponseModel MapDTOToModel(
			DTOVendor dtoVendor);

		List<ApiVendorResponseModel> MapDTOToModel(
			List<DTOVendor> dtos);
	}
}

/*<Codenesium>
    <Hash>cc6484c2bb4d6e7ff258db431bc63c58</Hash>
</Codenesium>*/