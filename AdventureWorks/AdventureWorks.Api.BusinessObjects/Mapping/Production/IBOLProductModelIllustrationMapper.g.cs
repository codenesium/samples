using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductModelIllustrationMapper
	{
		DTOProductModelIllustration MapModelToDTO(
			int productModelID,
			ApiProductModelIllustrationRequestModel model);

		ApiProductModelIllustrationResponseModel MapDTOToModel(
			DTOProductModelIllustration dtoProductModelIllustration);

		List<ApiProductModelIllustrationResponseModel> MapDTOToModel(
			List<DTOProductModelIllustration> dtos);
	}
}

/*<Codenesium>
    <Hash>f747ad25126054ba233b0e1630a7c00c</Hash>
</Codenesium>*/