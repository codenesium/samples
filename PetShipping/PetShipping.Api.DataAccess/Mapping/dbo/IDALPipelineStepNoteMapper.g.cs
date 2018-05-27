using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineStepNoteMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipelineStepNote dto,
			PipelineStepNote efPipelineStepNote);

		DTOPipelineStepNote MapEFToDTO(
			PipelineStepNote efPipelineStepNote);
	}
}

/*<Codenesium>
    <Hash>e4c93d65c2cd5a3d5eb5e94ed65a319f</Hash>
</Codenesium>*/