using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineStepStatusMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipelineStepStatus dto,
			PipelineStepStatus efPipelineStepStatus);

		DTOPipelineStepStatus MapEFToDTO(
			PipelineStepStatus efPipelineStepStatus);
	}
}

/*<Codenesium>
    <Hash>fccdc56059fdd8ba9313e7c66bb473d8</Hash>
</Codenesium>*/