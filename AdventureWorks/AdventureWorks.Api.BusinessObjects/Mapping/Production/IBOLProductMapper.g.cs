using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductMapper
	{
		DTOProduct MapModelToDTO(
			int productID,
			ApiProductRequestModel model);

		ApiProductResponseModel MapDTOToModel(
			DTOProduct dtoProduct);

		List<ApiProductResponseModel> MapDTOToModel(
			List<DTOProduct> dtos);
	}
}

/*<Codenesium>
    <Hash>5ea055daa55bdaf25d38827d32c86bdc</Hash>
</Codenesium>*/