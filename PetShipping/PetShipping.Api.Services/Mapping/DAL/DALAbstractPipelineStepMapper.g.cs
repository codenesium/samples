using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractPipelineStepMapper
        {
                public virtual PipelineStep MapBOToEF(
                        BOPipelineStep bo)
                {
                        PipelineStep efPipelineStep = new PipelineStep();
                        efPipelineStep.SetProperties(
                                bo.Id,
                                bo.Name,
                                bo.PipelineStepStatusId,
                                bo.ShipperId);
                        return efPipelineStep;
                }

                public virtual BOPipelineStep MapEFToBO(
                        PipelineStep ef)
                {
                        var bo = new BOPipelineStep();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name,
                                ef.PipelineStepStatusId,
                                ef.ShipperId);
                        return bo;
                }

                public virtual List<BOPipelineStep> MapEFToBO(
                        List<PipelineStep> records)
                {
                        List<BOPipelineStep> response = new List<BOPipelineStep>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6b59d4a9bba4b39199fdf6db928329b5</Hash>
</Codenesium>*/