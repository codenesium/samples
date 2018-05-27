using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPasswordMapper
	{
		DTOPassword MapModelToDTO(
			int businessEntityID,
			ApiPasswordRequestModel model);

		ApiPasswordResponseModel MapDTOToModel(
			DTOPassword dtoPassword);

		List<ApiPasswordResponseModel> MapDTOToModel(
			List<DTOPassword> dtos);
	}
}

/*<Codenesium>
    <Hash>ef565d144ad97532242fc9737e2128ad</Hash>
</Codenesium>*/