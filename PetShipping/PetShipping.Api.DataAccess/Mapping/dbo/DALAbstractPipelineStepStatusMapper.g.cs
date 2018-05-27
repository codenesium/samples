using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineStepStatusMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipelineStepStatus dto,
			PipelineStepStatus efPipelineStepStatus)
		{
			efPipelineStepStatus.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOPipelineStepStatus MapEFToDTO(
			PipelineStepStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipelineStepStatus();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>6c1694161d6268d3efb20dced2d7d683</Hash>
</Codenesium>*/