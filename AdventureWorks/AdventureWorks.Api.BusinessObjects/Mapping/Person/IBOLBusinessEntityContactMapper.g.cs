using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLBusinessEntityContactMapper
	{
		DTOBusinessEntityContact MapModelToDTO(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model);

		ApiBusinessEntityContactResponseModel MapDTOToModel(
			DTOBusinessEntityContact dtoBusinessEntityContact);

		List<ApiBusinessEntityContactResponseModel> MapDTOToModel(
			List<DTOBusinessEntityContact> dtos);
	}
}

/*<Codenesium>
    <Hash>2a601270c2ac144bced3198581a6ff80</Hash>
</Codenesium>*/