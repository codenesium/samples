using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepNoteMapper
	{
		public virtual BOPipelineStepNote MapModelToBO(
			int id,
			ApiPipelineStepNoteServerRequestModel model
			)
		{
			BOPipelineStepNote boPipelineStepNote = new BOPipelineStepNote();
			boPipelineStepNote.SetProperties(
				id,
				model.EmployeeId,
				model.Note,
				model.PipelineStepId);
			return boPipelineStepNote;
		}

		public virtual ApiPipelineStepNoteServerResponseModel MapBOToModel(
			BOPipelineStepNote boPipelineStepNote)
		{
			var model = new ApiPipelineStepNoteServerResponseModel();

			model.SetProperties(boPipelineStepNote.Id, boPipelineStepNote.EmployeeId, boPipelineStepNote.Note, boPipelineStepNote.PipelineStepId);

			return model;
		}

		public virtual List<ApiPipelineStepNoteServerResponseModel> MapBOToModel(
			List<BOPipelineStepNote> items)
		{
			List<ApiPipelineStepNoteServerResponseModel> response = new List<ApiPipelineStepNoteServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7ce03656fdb70117387aeb6c1bf39b0e</Hash>
</Codenesium>*/