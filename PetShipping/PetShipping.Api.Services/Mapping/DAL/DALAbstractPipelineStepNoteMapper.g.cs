using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractPipelineStepNoteMapper
        {
                public virtual PipelineStepNote MapBOToEF(
                        BOPipelineStepNote bo)
                {
                        PipelineStepNote efPipelineStepNote = new PipelineStepNote();
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
    <Hash>a16411cdcefb0444ff3b7319946b6212</Hash>
</Codenesium>*/