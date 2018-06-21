using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractPipelineStepNoteMapper
        {
                public virtual BOPipelineStepNote MapModelToBO(
                        int id,
                        ApiPipelineStepNoteRequestModel model
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

                public virtual ApiPipelineStepNoteResponseModel MapBOToModel(
                        BOPipelineStepNote boPipelineStepNote)
                {
                        var model = new ApiPipelineStepNoteResponseModel();

                        model.SetProperties(boPipelineStepNote.EmployeeId, boPipelineStepNote.Id, boPipelineStepNote.Note, boPipelineStepNote.PipelineStepId);

                        return model;
                }

                public virtual List<ApiPipelineStepNoteResponseModel> MapBOToModel(
                        List<BOPipelineStepNote> items)
                {
                        List<ApiPipelineStepNoteResponseModel> response = new List<ApiPipelineStepNoteResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cbf55b517069076d0031bafd8aaa1278</Hash>
</Codenesium>*/