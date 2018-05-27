using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLScrapReasonMapper
	{
		DTOScrapReason MapModelToDTO(
			short scrapReasonID,
			ApiScrapReasonRequestModel model);

		ApiScrapReasonResponseModel MapDTOToModel(
			DTOScrapReason dtoScrapReason);

		List<ApiScrapReasonResponseModel> MapDTOToModel(
			List<DTOScrapReason> dtos);
	}
}

/*<Codenesium>
    <Hash>5902106238189b09f4cf45b5890329dd</Hash>
</Codenesium>*/