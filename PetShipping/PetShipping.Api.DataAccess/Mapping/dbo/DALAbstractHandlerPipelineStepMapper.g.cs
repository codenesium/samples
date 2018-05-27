using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALHandlerPipelineStepMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOHandlerPipelineStep dto,
			HandlerPipelineStep efHandlerPipelineStep)
		{
			efHandlerPipelineStep.SetProperties(
				id,
				dto.HandlerId,
				dto.PipelineStepId);
		}

		public virtual DTOHandlerPipelineStep MapEFToDTO(
			HandlerPipelineStep ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOHandlerPipelineStep();

			dto.SetProperties(
				ef.Id,
				ef.HandlerId,
				ef.PipelineStepId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>c9cdad7a6429fe9d61beb4419f74aec7</Hash>
</Codenesium>*/