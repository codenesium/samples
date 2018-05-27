using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductDocumentMapper
	{
		DTOProductDocument MapModelToDTO(
			int productID,
			ApiProductDocumentRequestModel model);

		ApiProductDocumentResponseModel MapDTOToModel(
			DTOProductDocument dtoProductDocument);

		List<ApiProductDocumentResponseModel> MapDTOToModel(
			List<DTOProductDocument> dtos);
	}
}

/*<Codenesium>
    <Hash>bf416097642bfdb1dc36906889f125cb</Hash>
</Codenesium>*/