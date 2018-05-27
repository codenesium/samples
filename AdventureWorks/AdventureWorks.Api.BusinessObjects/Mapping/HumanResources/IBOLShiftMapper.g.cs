using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLShiftMapper
	{
		DTOShift MapModelToDTO(
			int shiftID,
			ApiShiftRequestModel model);

		ApiShiftResponseModel MapDTOToModel(
			DTOShift dtoShift);

		List<ApiShiftResponseModel> MapDTOToModel(
			List<DTOShift> dtos);
	}
}

/*<Codenesium>
    <Hash>1377bbf843f9f766f97f4e0faf86236d</Hash>
</Codenesium>*/