using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineStepDestinationMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipelineStepDestination dto,
			PipelineStepDestination efPipelineStepDestination);

		DTOPipelineStepDestination MapEFToDTO(
			PipelineStepDestination efPipelineStepDestination);
	}
}

/*<Codenesium>
    <Hash>38a7adeb2475e5aeac5e75237818ed6b</Hash>
</Codenesium>*/