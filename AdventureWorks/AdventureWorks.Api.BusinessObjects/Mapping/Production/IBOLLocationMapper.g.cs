using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLLocationMapper
	{
		DTOLocation MapModelToDTO(
			short locationID,
			ApiLocationRequestModel model);

		ApiLocationResponseModel MapDTOToModel(
			DTOLocation dtoLocation);

		List<ApiLocationResponseModel> MapDTOToModel(
			List<DTOLocation> dtos);
	}
}

/*<Codenesium>
    <Hash>176e549077a006c2dd85f297b8542f62</Hash>
</Codenesium>*/