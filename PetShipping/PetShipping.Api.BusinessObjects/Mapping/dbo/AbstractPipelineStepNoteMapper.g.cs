using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineStepNoteMapper
	{
		public virtual DTOPipelineStepNote MapModelToDTO(
			int id,
			ApiPipelineStepNoteRequestModel model
			)
		{
			DTOPipelineStepNote dtoPipelineStepNote = new DTOPipelineStepNote();

			dtoPipelineStepNote.SetProperties(
				id,
				model.EmployeeId,
				model.Note,
				model.PipelineStepId);
			return dtoPipelineStepNote;
		}

		public virtual ApiPipelineStepNoteResponseModel MapDTOToModel(
			DTOPipelineStepNote dtoPipelineStepNote)
		{
			if (dtoPipelineStepNote == null)
			{
				return null;
			}

			var model = new ApiPipelineStepNoteResponseModel();

			model.SetProperties(dtoPipelineStepNote.EmployeeId, dtoPipelineStepNote.Id, dtoPipelineStepNote.Note, dtoPipelineStepNote.PipelineStepId);

			return model;
		}

		public virtual List<ApiPipelineStepNoteResponseModel> MapDTOToModel(
			List<DTOPipelineStepNote> dtos)
		{
			List<ApiPipelineStepNoteResponseModel> response = new List<ApiPipelineStepNoteResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>335407c0da5aa99547b0305128882b56</Hash>
</Codenesium>*/