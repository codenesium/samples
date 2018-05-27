using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLContactTypeMapper
	{
		DTOContactType MapModelToDTO(
			int contactTypeID,
			ApiContactTypeRequestModel model);

		ApiContactTypeResponseModel MapDTOToModel(
			DTOContactType dtoContactType);

		List<ApiContactTypeResponseModel> MapDTOToModel(
			List<DTOContactType> dtos);
	}
}

/*<Codenesium>
    <Hash>6c70712952fdf90d7125ead7369f7f7b</Hash>
</Codenesium>*/