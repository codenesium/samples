using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepNoteMapper
	{
		public virtual BOPipelineStepNote MapModelToBO(
			int id,
			ApiPipelineStepNoteRequestModel model
			)
		{
			BOPipelineStepNote BOPipelineStepNote = new BOPipelineStepNote();

			BOPipelineStepNote.SetProperties(
				id,
				model.EmployeeId,
				model.Note,
				model.PipelineStepId);
			return BOPipelineStepNote;
		}

		public virtual ApiPipelineStepNoteResponseModel MapBOToModel(
			BOPipelineStepNote BOPipelineStepNote)
		{
			if (BOPipelineStepNote == null)
			{
				return null;
			}

			var model = new ApiPipelineStepNoteResponseModel();

			model.SetProperties(BOPipelineStepNote.EmployeeId, BOPipelineStepNote.Id, BOPipelineStepNote.Note, BOPipelineStepNote.PipelineStepId);

			return model;
		}

		public virtual List<ApiPipelineStepNoteResponseModel> MapBOToModel(
			List<BOPipelineStepNote> BOs)
		{
			List<ApiPipelineStepNoteResponseModel> response = new List<ApiPipelineStepNoteResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9f7562b927a4b088d766f4c1a7ce3549</Hash>
</Codenesium>*/