using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductDescriptionMapper
	{
		DTOProductDescription MapModelToDTO(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model);

		ApiProductDescriptionResponseModel MapDTOToModel(
			DTOProductDescription dtoProductDescription);

		List<ApiProductDescriptionResponseModel> MapDTOToModel(
			List<DTOProductDescription> dtos);
	}
}

/*<Codenesium>
    <Hash>9c6fe8ef920cca48b25ee774ba674ebd</Hash>
</Codenesium>*/