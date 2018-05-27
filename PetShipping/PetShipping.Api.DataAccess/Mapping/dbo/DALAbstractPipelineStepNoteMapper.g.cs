using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALPipelineStepNoteMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPipelineStepNote dto,
			PipelineStepNote efPipelineStepNote)
		{
			efPipelineStepNote.SetProperties(
				id,
				dto.EmployeeId,
				dto.Note,
				dto.PipelineStepId);
		}

		public virtual DTOPipelineStepNote MapEFToDTO(
			PipelineStepNote ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPipelineStepNote();

			dto.SetProperties(
				ef.Id,
				ef.EmployeeId,
				ef.Note,
				ef.PipelineStepId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>35eaa7a63341c7a7201d74d7a3bb82c2</Hash>
</Codenesium>*/