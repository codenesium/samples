using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineStepMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipelineStep dto,
			PipelineStep efPipelineStep);

		DTOPipelineStep MapEFToDTO(
			PipelineStep efPipelineStep);
	}
}

/*<Codenesium>
    <Hash>d5800501b35a5ed0e9fc0338f59950c7</Hash>
</Codenesium>*/