using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCultureMapper
	{
		DTOCulture MapModelToDTO(
			string cultureID,
			ApiCultureRequestModel model);

		ApiCultureResponseModel MapDTOToModel(
			DTOCulture dtoCulture);

		List<ApiCultureResponseModel> MapDTOToModel(
			List<DTOCulture> dtos);
	}
}

/*<Codenesium>
    <Hash>8f94fe750c5a6265f8142333421e847c</Hash>
</Codenesium>*/