using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLIllustrationMapper
	{
		DTOIllustration MapModelToDTO(
			int illustrationID,
			ApiIllustrationRequestModel model);

		ApiIllustrationResponseModel MapDTOToModel(
			DTOIllustration dtoIllustration);

		List<ApiIllustrationResponseModel> MapDTOToModel(
			List<DTOIllustration> dtos);
	}
}

/*<Codenesium>
    <Hash>4f5ad009857347f09b53d19d29ef11c8</Hash>
</Codenesium>*/