using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLDocumentMapper
	{
		DTODocument MapModelToDTO(
			Guid documentNode,
			ApiDocumentRequestModel model);

		ApiDocumentResponseModel MapDTOToModel(
			DTODocument dtoDocument);

		List<ApiDocumentResponseModel> MapDTOToModel(
			List<DTODocument> dtos);
	}
}

/*<Codenesium>
    <Hash>0eae936ffe763916672b176876f67930</Hash>
</Codenesium>*/