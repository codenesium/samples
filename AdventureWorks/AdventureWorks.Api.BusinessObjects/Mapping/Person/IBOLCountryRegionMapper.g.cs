using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCountryRegionMapper
	{
		DTOCountryRegion MapModelToDTO(
			string countryRegionCode,
			ApiCountryRegionRequestModel model);

		ApiCountryRegionResponseModel MapDTOToModel(
			DTOCountryRegion dtoCountryRegion);

		List<ApiCountryRegionResponseModel> MapDTOToModel(
			List<DTOCountryRegion> dtos);
	}
}

/*<Codenesium>
    <Hash>0c2af3ca27336da833dbf8640cdf695b</Hash>
</Codenesium>*/