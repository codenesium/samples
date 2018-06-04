using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepNoteMapper
	{
		public virtual PipelineStepNote MapBOToEF(
			BOPipelineStepNote bo)
		{
			PipelineStepNote efPipelineStepNote = new PipelineStepNote ();

			efPipelineStepNote.SetProperties(
				bo.EmployeeId,
				bo.Id,
				bo.Note,
				bo.PipelineStepId);
			return efPipelineStepNote;
		}

		public virtual BOPipelineStepNote MapEFToBO(
			PipelineStepNote ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPipelineStepNote();

			bo.SetProperties(
				ef.Id,
				ef.EmployeeId,
				ef.Note,
				ef.PipelineStepId);
			return bo;
		}

		public virtual List<BOPipelineStepNote> MapEFToBO(
			List<PipelineStepNote> records)
		{
			List<BOPipelineStepNote> response = new List<BOPipelineStepNote>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4ff0b03c0d97b9f3c0408e320a51565d</Hash>
</Codenesium>*/