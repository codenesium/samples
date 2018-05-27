using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLMachineMapper
	{
		DTOMachine MapModelToDTO(
			int id,
			ApiMachineRequestModel model);

		ApiMachineResponseModel MapDTOToModel(
			DTOMachine dtoMachine);

		List<ApiMachineResponseModel> MapDTOToModel(
			List<DTOMachine> dtos);
	}
}

/*<Codenesium>
    <Hash>c97d2377bc08f51078e3af04f6810efb</Hash>
</Codenesium>*/